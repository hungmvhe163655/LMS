import { SortableContext, useSortable, verticalListSortingStrategy } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import { Pencil2Icon, TrashIcon } from '@radix-ui/react-icons';
import { Dispatch, FC, SetStateAction, useState } from 'react';

import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

import { useAddNewTask } from '../api/add-new-task'; // Import the add new task hook
import { useDeleteTaskList } from '../api/delete-tasklist'; // Import the delete task list hook
import type { Task, TaskList as TaskListType } from '../types/project-types';

import SortableTask from './sortable-task';
import UpdateTaskListDialog from './update-task-list-dialog'; // Import the new dialog component

interface TaskListProps {
  taskList: TaskListType;
  tasks: Task[];
  projectId: string | undefined;
  setTasks: Dispatch<SetStateAction<TaskListType[]>>;
  setIsDialogOpen: Dispatch<SetStateAction<boolean>>; // Add setIsDialogOpen prop
}

const SortableTaskList: FC<TaskListProps> = ({
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
  const { mutate: deleteTaskListMutate } = useDeleteTaskList();

  const handleAddTask = () => {
    if (newTaskTitle.trim()) {
      addNewTaskMutate(
        {
          title: newTaskTitle,
          taskListId: taskList.id,
          projectId: projectId || ''
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

  const handleDeleteTaskList = () => {
    deleteTaskListMutate(taskList.id, {
      onSuccess: () => {
        setTasks((prev) => prev.filter((list) => list.id !== taskList.id));
      }
    });
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
    <li
      ref={setNodeRef}
      style={style}
      {...attributes}
      {...listeners}
      className='relative w-full overflow-auto rounded-md border bg-slate-300 px-4 shadow-md'
    >
      <div className='sticky top-0 flex justify-between bg-slate-300 p-3 align-middle'>
        <h3 className='text-xl font-semibold'>
          <div>{taskList.name}</div>
          {/* <div>{taskList.id}</div> */}
          {/* <span className='text-sm'>({taskList.maxTasks?.valueOf()} Max Tasks)</span> */}
        </h3>
        <div className='flex space-x-2 align-middle'>
          <Button
            variant='success'
            size='sm'
            onClick={() => setIsUpdateDialogOpen(true)}
            data-no-dnd='true'
          >
            <Pencil2Icon />
          </Button>
          <Button variant='destructive' size='sm' onClick={handleDeleteTaskList} data-no-dnd='true'>
            <TrashIcon />
          </Button>
        </div>
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
          data-no-dnd='true'
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
    </li>
  );
};

export default SortableTaskList;
