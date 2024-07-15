import { SortableContext, useSortable, verticalListSortingStrategy } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import React, { useState } from 'react';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

import type { Task, TaskList as TaskListType } from '../types/workspace-types';

import SortableTask from './sortable-task';

interface TaskListProps {
  taskList: TaskListType;
  tasks: Task[];
  setTasks: React.Dispatch<React.SetStateAction<TaskListType[]>>;
}

const SortableTaskList: React.FC<TaskListProps> = ({ taskList, tasks, setTasks }) => {
  const { attributes, listeners, setNodeRef, transform, transition } = useSortable({
    id: taskList.id,
    data: { type: 'TaskList' }
  });

  const style = {
    transform: CSS.Transform.toString(transform),
    transition
  };

  const [newTaskTitle, setNewTaskTitle] = useState('');

  const handleAddTask = () => {
    if (newTaskTitle.trim()) {
      setTasks((prev) => {
        return prev.map((list) => {
          if (list.id === taskList.id) {
            return {
              ...list,
              tasks: [
                ...list.tasks,
                {
                  id: `task-${Math.random().toString(36).substr(2, 9)}`,
                  title: newTaskTitle,
                  assignedTo: 'You'
                } as Task
              ]
            };
          }
          return list;
        });
      });
      setNewTaskTitle('');
    }
  };

  const renderPlaceholderTask = () => {
    if (tasks.length === 0) {
      return (
        <div className='h-0 w-full overflow-hidden' aria-hidden='true'>
          {/* Placeholder task content */}
        </div>
      );
    }
    return null;
  };

  return (
    <div
      ref={setNodeRef}
      style={style}
      {...attributes}
      {...listeners}
      className='w-80 rounded-md border bg-white p-4 shadow-md'
    >
      <h3 className='mb-4 text-xl font-semibold'>{taskList.name}</h3>
      <SortableContext items={tasks.map((task) => task.id)} strategy={verticalListSortingStrategy}>
        {renderPlaceholderTask()}
        {tasks.map((task) => (
          <SortableTask key={task.id} task={task} />
        ))}
      </SortableContext>
      <div className='mt-4'>
        <Input
          value={newTaskTitle}
          onChange={(e) => setNewTaskTitle(e.target.value)}
          placeholder='New task title'
          className='mb-2'
          data-no-dnd='true' // Added data-no-dnd attribute
        />
        <Button onClick={handleAddTask} className='w-full' data-no-dnd='true'>
          Add New Task
        </Button>
      </div>
    </div>
  );
};

export default SortableTaskList;
