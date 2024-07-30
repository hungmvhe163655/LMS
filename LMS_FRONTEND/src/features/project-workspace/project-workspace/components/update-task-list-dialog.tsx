import { zodResolver } from '@hookform/resolvers/zod';
import React from 'react';
import { useForm } from 'react-hook-form';
import { z } from 'zod';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter
} from '@/components/ui/dialog';
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage
} from '@/components/ui/form';
import { Input } from '@/components/ui/input';

import { useUpdateTaskList } from '../api/update-task-list'; // Correct import
import { TaskList } from '../types/project-types';

const taskListSchema = z.object({
  name: z.string().nonempty('Name is required'),
  maxTasks: z.preprocess(
    (val) => Number(val),
    z.number().positive('Max tasks must be greater than 0')
  )
});

type TaskListFormData = z.infer<typeof taskListSchema>;

interface UpdateTaskListDialogProps {
  isOpen: boolean;
  onClose: () => void;
  taskList: TaskList;
  setTasks: React.Dispatch<React.SetStateAction<TaskList[]>>;
}

const UpdateTaskListDialog: React.FC<UpdateTaskListDialogProps> = ({
  isOpen,
  onClose,
  taskList,
  setTasks
}) => {
  const { mutate: updateTaskList } = useUpdateTaskList({
    mutationConfig: {
      onSuccess: (updatedTaskList) => {
        setTasks((prev) =>
          prev.map((list) => (list.id === updatedTaskList.id ? updatedTaskList : list))
        );
      }
    }
  });

  const form = useForm<TaskListFormData>({
    resolver: zodResolver(taskListSchema),
    defaultValues: {
      name: taskList.name,
      maxTasks: taskList.maxTasks
    }
  });

  const handleFormSubmit = (data: TaskListFormData) => {
    updateTaskList({
      id: taskList.id,
      name: data.name,
      maxTasks: data.maxTasks
    });
    onClose();
  };

  return (
    <Dialog open={isOpen} onOpenChange={onClose}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Update Task List</DialogTitle>
        </DialogHeader>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(handleFormSubmit)} className='space-y-4'>
            <FormField
              control={form.control}
              name='name'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Name</FormLabel>
                  <FormControl>
                    <Input {...field} placeholder='Task List name' />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name='maxTasks'
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Max Tasks</FormLabel>
                  <FormControl>
                    <Input {...field} type='number' placeholder='Max tasks' />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <DialogFooter>
              <Button variant='outline' onClick={onClose}>
                Cancel
              </Button>
              <Button type='submit'>Update</Button>
            </DialogFooter>
          </form>
        </Form>
      </DialogContent>
    </Dialog>
  );
};

export default UpdateTaskListDialog;
