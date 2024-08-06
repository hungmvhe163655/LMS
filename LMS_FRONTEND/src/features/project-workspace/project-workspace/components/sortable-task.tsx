import { useSortable } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import { zodResolver } from '@hookform/resolvers/zod';
import { DialogDescription } from '@radix-ui/react-dialog';
import { CalendarIcon } from '@radix-ui/react-icons';
import { addDays, format } from 'date-fns';
import React, { useState, useEffect } from 'react';
import { DateRange } from 'react-day-picker';
import { useForm, Controller } from 'react-hook-form';
import { useParams } from 'react-router-dom';
import * as z from 'zod';

import CommentSection from '@/components/app/comment-section';
import HistorySection from '@/components/app/history-section';
import { Button } from '@/components/ui/button';
import { Calendar } from '@/components/ui/calendar';
import { Card, CardHeader, CardTitle, CardContent } from '@/components/ui/card';
import { Checkbox } from '@/components/ui/checkbox';
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter,
  DialogTrigger
} from '@/components/ui/dialog';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { Popover, PopoverContent, PopoverTrigger } from '@/components/ui/popover';
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue
} from '@/components/ui/select';
import { Tabs, TabsContent, TabsList, TabsTrigger } from '@/components/ui/tabs';

import { useProjectMembers } from '../../project-members/api/get-project-members';
import { useDeleteTask } from '../api/delete-task';
import { useUpdateTask, UpdateTaskPayload } from '../api/update-task';
import { Task } from '../types/project-types';

interface SortableTaskProps {
  task: Task;
  setIsDialogOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

const TaskSchema = z.object({
  id: z.string(),
  title: z.string().nonempty('Title is required'),
  requiredValidation: z.boolean(),
  description: z.string().optional(),
  startDate: z.string().nonempty('Start date is required'),
  dueDate: z.string().nonempty('Due date is required'),
  taskPriority: z.enum(['urgent', 'high', 'medium', 'low']),
  taskStatus: z.enum(['todo', 'doing', 'done']),
  assignedTo: z.string().optional()
});

const SortableTask: React.FC<SortableTaskProps> = ({ task, setIsDialogOpen }) => {
  const { projectId } = useParams<{ projectId: string }>();
  const { attributes, listeners, setNodeRef, transform, transition } = useSortable({
    id: task.id,
    data: { type: 'Task', order: task.order }
  });
  const [isOpen, setIsOpen] = useState(false);
  const [dateRange, setDateRange] = useState<DateRange | undefined>({
    from: new Date(),
    to: addDays(new Date(), 7)
  });

  const style = {
    transform: CSS.Transform.toString(transform),
    transition
  };

  const { mutate: deleteTaskMutate } = useDeleteTask({
    mutationConfig: {
      onSuccess: () => {
        setIsOpen(false);
      }
    }
  });

  const { mutate: updateTaskMutate } = useUpdateTask({
    mutationConfig: {
      onSuccess: () => {
        setIsOpen(false);
      }
    }
  });

  const { data: members } = useProjectMembers({ projectId });

  const {
    control,
    handleSubmit,
    formState: { errors },
    setValue
  } = useForm<UpdateTaskPayload>({
    resolver: zodResolver(TaskSchema),
    defaultValues: {
      id: task.id,
      title: task.title,
      requiredValidation: false,
      description: task.description,
      startDate: dateRange?.from?.toISOString() || '',
      dueDate: dateRange?.to?.toISOString() || '',
      taskPriority: 'medium',
      taskStatus: 'todo',
      assignedTo: 'None'
    }
  });

  const handleDialogOpenChange = (isOpen: boolean) => {
    setIsOpen(isOpen);
    setIsDialogOpen(isOpen);
  };

  const handleDeleteTask = () => {
    deleteTaskMutate(task.id);
  };

  const onSubmit = (data: UpdateTaskPayload) => {
    updateTaskMutate(data);
  };

  useEffect(() => {
    if (dateRange?.from && dateRange?.to) {
      setValue('startDate', dateRange.from.toISOString());
      setValue('dueDate', dateRange.to.toISOString());
    }
  }, [dateRange, setValue]);

  return (
    <Dialog open={isOpen} onOpenChange={handleDialogOpenChange}>
      <DialogTrigger asChild>
        <Card
          ref={setNodeRef}
          style={style}
          {...attributes}
          {...listeners}
          className='mb-2 cursor-pointer'
        >
          <CardHeader>
            <CardTitle>{task.id}</CardTitle>
          </CardHeader>
          <CardContent>
            <p className='text-lg font-bold'>{task.id}</p>
            <p className='text-lg '>
              {task.description.trim() === '' ? 'No description' : task.description}
            </p>
            <p className='text-sm'>
              {task.assignedToUser === 'NotFound' ? 'Not Assigned' : task.assignedToUser}
            </p>
            <Button onClick={() => handleDialogOpenChange(true)} data-no-dnd='true'>
              → View Detail
            </Button>
          </CardContent>
        </Card>
      </DialogTrigger>
      <DialogContent className='sm:max-w-[800px]'>
        <DialogHeader>
          <DialogTitle>{task.title}</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit(onSubmit)} className='grid gap-4 py-4'>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='priority' className='text-right'>
              Priority
            </Label>
            <Controller
              name='taskPriority'
              control={control}
              render={({ field }) => (
                <Select {...field} onValueChange={field.onChange}>
                  <SelectTrigger className='w-[180px]'>
                    <SelectValue placeholder='Priority' />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value='urgent'>Urgent</SelectItem>
                    <SelectItem value='high'>High</SelectItem>
                    <SelectItem value='medium'>Medium</SelectItem>
                    <SelectItem value='low'>Low</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
            {errors.taskPriority && (
              <span className='text-red-500'>{errors.taskPriority.message}</span>
            )}
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='assignedTo' className='text-right'>
              Assign to
            </Label>
            <Controller
              name='assignedTo'
              control={control}
              render={({ field }) => (
                <Select {...field} onValueChange={field.onChange}>
                  <SelectTrigger className='w-[180px]'>
                    <SelectValue placeholder='Assign to' />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem key={null} value={'None'}>
                      None
                    </SelectItem>
                    {members?.map((member) => (
                      <SelectItem key={member.userId} value={member.userId}>
                        {member.fullName}
                      </SelectItem>
                    ))}
                  </SelectContent>
                </Select>
              )}
            />
            {errors.assignedTo && <span className='text-red-500'>{errors.assignedTo.message}</span>}
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='status' className='text-right'>
              Task Status
            </Label>
            <Controller
              name='taskStatus'
              control={control}
              render={({ field }) => (
                <Select {...field} onValueChange={field.onChange}>
                  <SelectTrigger className='w-[180px]'>
                    <SelectValue placeholder='Task Status' />
                  </SelectTrigger>
                  <SelectContent>
                    <SelectItem value='todo'>To Do</SelectItem>
                    <SelectItem value='doing'>Doing</SelectItem>
                    <SelectItem value='done'>Done</SelectItem>
                  </SelectContent>
                </Select>
              )}
            />
            {errors.taskStatus && <span className='text-red-500'>{errors.taskStatus.message}</span>}
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='description' className='text-right'>
              Description
            </Label>
            <Controller
              name='description'
              control={control}
              render={({ field }) => (
                <Input
                  {...field}
                  id='description'
                  className='col-span-3'
                  defaultValue={task.description}
                  data-no-dnd='true'
                />
              )}
            />
            {errors.description && (
              <span className='text-red-500'>{errors.description.message}</span>
            )}
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='dateRange' className='text-right'>
              Date Range
            </Label>
            <div className='col-span-3'>
              <Popover>
                <PopoverTrigger asChild>
                  <Button
                    id='date'
                    variant={'outline'}
                    className='w-[300px] justify-start text-left font-normal'
                  >
                    <CalendarIcon className='mr-2 size-4' />
                    {dateRange?.from ? (
                      dateRange.to ? (
                        <>
                          {format(dateRange.from, 'LLL dd, y')} -{' '}
                          {format(dateRange.to, 'LLL dd, y')}
                        </>
                      ) : (
                        format(dateRange.from, 'LLL dd, y')
                      )
                    ) : (
                      <span>Pick a date</span>
                    )}
                  </Button>
                </PopoverTrigger>
                <PopoverContent className='w-auto p-0' align='start'>
                  <Calendar
                    initialFocus
                    mode='range'
                    defaultMonth={dateRange?.from}
                    selected={dateRange}
                    onSelect={setDateRange}
                    numberOfMonths={2}
                  />
                </PopoverContent>
              </Popover>
            </div>
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='requiredValidation' className='text-right'>
              Required Validation
            </Label>
            <Controller
              name='requiredValidation'
              control={control}
              render={({ field }) => (
                <Checkbox
                  {...field}
                  id='requiredValidation'
                  checked={field.value}
                  onCheckedChange={(checked) => field.onChange(checked === true)}
                  className='col-span-3'
                  value={field.value ? 'true' : 'false'} // Add value prop as a string
                />
              )}
            />
            {errors.requiredValidation && (
              <span className='text-red-500'>{errors.requiredValidation.message}</span>
            )}
          </div>
          <div className='mt-4 border-t pt-4'>
            <Tabs defaultValue='comment' className='w-full'>
              <TabsList className='grid w-full grid-cols-2'>
                <TabsTrigger value='comment'>Comment</TabsTrigger>
                <TabsTrigger value='history'>History</TabsTrigger>
              </TabsList>
              <TabsContent value='comment'>
                <CommentSection />
              </TabsContent>
              <TabsContent value='history'>
                <HistorySection />
              </TabsContent>
            </Tabs>
          </div>
          <DialogFooter>
            <Button variant='destructive' size='sm' onClick={handleDeleteTask} data-no-dnd='true'>
              Delete
            </Button>
            <Button variant='outline' onClick={() => handleDialogOpenChange(false)}>
              Cancel
            </Button>
            <Button type='submit'>Save changes</Button>
          </DialogFooter>
        </form>
      </DialogContent>
      <DialogDescription></DialogDescription>
    </Dialog>
  );
};

export default SortableTask;
