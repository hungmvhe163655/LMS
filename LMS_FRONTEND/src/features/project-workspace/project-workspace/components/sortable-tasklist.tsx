import { SortableContext, useSortable, verticalListSortingStrategy } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import React, { useState } from 'react';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

import { useAddNewTask } from '../api/add-new-task'; // Import the add new task hook
import type { Task, TaskList as TaskListType } from '../types/project-types';

import SortableTask from './sortable-task';
import UpdateTaskListDialog from './update-task-list-dialog'; // Import the new dialog component

interface TaskListProps {
  taskList: TaskListType;
  tasks: Task[];
  projectId: string | undefined;
  setTasks: React.Dispatch<React.SetStateAction<TaskListType[]>>;
  setIsDialogOpen: React.Dispatch<React.SetStateAction<boolean>>; // Add setIsDialogOpen prop
}

const SortableTaskList: React.FC<TaskListProps> = ({
  taskList,
  tasks,
  setTasks,
  setIsDialogOpen,
  projectId
}) => {
  const { attributes, listeners, setNodeRef, transform, transition } = useSortable({
    id: taskList.id,
    data: { type: 'TaskList' }
  });

  const style = {
    transform: CSS.Transform.toString(transform),
    transition
  };

  const [newTaskTitle, setNewTaskTitle] = useState('');
  const [isUpdateDialogOpen, setIsUpdateDialogOpen] = useState(false);

  const { mutate: addNewTaskMutate } = useAddNewTask();

  const handleAddTask = () => {
    if (newTaskTitle.trim()) {
      addNewTaskMutate(
        {
          title: newTaskTitle,
          taskListId: taskList.id,
          projectId: projectId
        },
        {
          onSuccess: (newTask) => {
            setTasks((prev) => {
              return prev.map((list) => {
                if (list.id === taskList.id) {
                  return {
                    ...list,
                    tasks: [...list.tasks, newTask]
                  };
                }
                return list;
              });
            });
            setNewTaskTitle('');
          }
        }
      );
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
      <div className='mb-2 flex items-center justify-between'>
        <h3 className='text-xl font-semibold'>
          {taskList.name} <span>{taskList.id}</span>
          {/* <span className='text-sm'>({taskList.maxTasks?.valueOf()} Max Tasks)</span> */}
        </h3>
        <Button
          variant='outline'
          size='sm'
          onClick={() => setIsUpdateDialogOpen(true)}
          data-no-dnd='true'
        >
          Edit
        </Button>
        <Button variant='destructive' size='sm' data-no-dnd='true'>
          Delete
        </Button>
      </div>
      <hr className='my-2' />
      <SortableContext items={tasks.map((task) => task.id)} strategy={verticalListSortingStrategy}>
        {renderPlaceholderTask()}
        {tasks.map((task) => (
          <SortableTask
            key={task.id}
            task={task}
            setIsDialogOpen={setIsDialogOpen} // Pass the state setter to children
          />
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
      <UpdateTaskListDialog
        isOpen={isUpdateDialogOpen}
        onClose={() => setIsUpdateDialogOpen(false)}
        taskList={taskList}
        setTasks={setTasks}
      />
    </div>
  );
};

export default SortableTaskList;
