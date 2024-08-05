import { useSortable } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import React, { useState } from 'react';

import CommentSection from '@/components/app/comment-section'; // Assuming these are in the same directory
import HistorySection from '@/components/app/history-section';
import { Button } from '@/components/ui/button';
import { Card, CardHeader, CardTitle, CardContent } from '@/components/ui/card';
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
import { Tabs, TabsContent, TabsList, TabsTrigger } from '@/components/ui/tabs';
import type { Task } from '@/features/project-workspace/project-workspace/types/project-types';

import { useDeleteTask } from '../api/delete-task';

interface SortableTaskProps {
  task: Task;
  setIsDialogOpen: React.Dispatch<React.SetStateAction<boolean>>; // Add setIsDialogOpen prop
}

const SortableTask: React.FC<SortableTaskProps> = ({ task, setIsDialogOpen }) => {
  const { attributes, listeners, setNodeRef, transform, transition } = useSortable({
    id: task.id,
    data: { type: 'Task', order: task.order }
  });
  const [isOpen, setIsOpen] = useState(false);

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

  const handleDialogOpenChange = (isOpen: boolean) => {
    setIsOpen(isOpen);
    setIsDialogOpen(isOpen);
  };

  const handleDeleteTask = () => {
    deleteTaskMutate(task.id);
  };

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
              {task.description.trim() == '' ? 'No description' : task.description}
            </p>
            <p className='text-sm'>
              {task.assignedToUser == 'NotFound' ? 'Not Assigned' : task.assignedToUser}
            </p>
            {/* <p>Order: {task.order}</p> */}
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
        <div className='grid gap-4 py-4'>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='priority' className='text-right'>
              Priority
            </Label>
            <select id='priority' className='col-span-3' data-no-dnd='true'>
              <option value='urgent'>Urgent</option>
              <option value='high'>High</option>
              <option value='medium'>Medium</option>
              <option value='low'>Low</option>
            </select>
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='assignedTo' className='text-right'>
              Assign to
            </Label>
            <Input
              id='assignedTo'
              defaultValue={task.assignedTo}
              className='col-span-3'
              data-no-dnd='true'
            />
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='status' className='text-right'>
              Task Status
            </Label>
            <select id='status' className='col-span-3' data-no-dnd='true'>
              <option value='todo'>To Do</option>
              <option value='doing'>Doing</option>
              <option value='done'>Done</option>
            </select>
          </div>
          <div className='grid grid-cols-4 items-center gap-4'>
            <Label htmlFor='description' className='text-right'>
              Description
            </Label>
            <Input
              id='description'
              className='col-span-3'
              defaultValue={task.description}
              data-no-dnd='true'
            />
          </div>
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
      </DialogContent>
    </Dialog>
  );
};

export default SortableTask;
