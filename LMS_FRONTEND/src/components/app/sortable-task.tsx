import { useSortable } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import React, { useState } from 'react';

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
import type { Task } from '@/features/project-workspace/project-workspace/workspace-types';

interface SortableTaskProps {
  task: Task;
}

const SortableTask: React.FC<SortableTaskProps> = ({ task }) => {
  const { attributes, listeners, setNodeRef, transform, transition } = useSortable({
    id: task.id,
    data: { type: 'Task' }
  });
  const [isOpen, setIsOpen] = useState(false);

  const style = {
    transform: CSS.Transform.toString(transform),
    transition
  };

  return (
    <>
      <Dialog>
        <DialogTrigger asChild>
          <Card
            ref={setNodeRef}
            style={style}
            {...attributes}
            {...listeners}
            className='mb-2 cursor-pointer'
            onClick={() => setIsOpen(true)}
          >
            <CardHeader>
              <CardTitle>{task.title}</CardTitle>
            </CardHeader>
            <CardContent>
              <p>ID: {task.id}</p>
              <p>Assigned to: {task.assignedTo}</p>
            </CardContent>
          </Card>

          <Dialog open={isOpen} onOpenChange={setIsOpen}>
            <DialogContent className='sm:max-w-[425px]'>
              <DialogHeader>
                <DialogTitle>{task.title}</DialogTitle>
              </DialogHeader>
              <div className='grid gap-4 py-4'>
                <div className='grid grid-cols-4 items-center gap-4'>
                  <Label htmlFor='priority' className='text-right'>
                    Priority
                  </Label>
                  <select id='priority' className='col-span-3'>
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
                  <Input id='assignedTo' defaultValue={task.assignedTo} className='col-span-3' />
                </div>
                <div className='grid grid-cols-4 items-center gap-4'>
                  <Label htmlFor='status' className='text-right'>
                    Task Status
                  </Label>
                  <select id='status' className='col-span-3'>
                    <option value='todo'>To Do</option>
                    <option value='doing'>Doing</option>
                    <option value='done'>Done</option>
                  </select>
                </div>
                <div className='grid grid-cols-4 items-center gap-4'>
                  <Label htmlFor='description' className='text-right'>
                    Description
                  </Label>
                  <Input id='description' className='col-span-3' defaultValue={task.description} />
                </div>
              </div>
              <DialogFooter>
                <Button variant='outline' onClick={() => setIsOpen(false)}>
                  Cancel
                </Button>
                <Button type='submit'>Save changes</Button>
              </DialogFooter>
            </DialogContent>
          </Dialog>
        </DialogTrigger>
      </Dialog>
    </>
  );
};

export default SortableTask;
