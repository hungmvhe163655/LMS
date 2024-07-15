import { DndContext, closestCenter, DragOverEvent } from '@dnd-kit/core';
import { SortableContext, useSortable, verticalListSortingStrategy } from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import React, { useState } from 'react';

import SortableTask from '@/components/app/sortable-task';
import { Button } from '@/components/ui/button';
import { Input } from '@/components/ui/input';

import { mockTaskLists } from './mock-tasks';
import type { Task, TaskList } from './workspace-types';

interface TaskListProps {
  taskList: TaskList;
  tasks: Task[];
  setTasks: React.Dispatch<React.SetStateAction<TaskList[]>>;
}

const TaskList: React.FC<TaskListProps> = ({ taskList, tasks, setTasks }) => {
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

  // Render a placeholder task if tasks array is empty
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
    <div className='w-80 rounded-md border bg-white p-4 shadow-md'>
      <h3 className='mb-4 text-xl font-semibold'>{taskList.name}</h3>
      <div ref={setNodeRef} style={style} {...attributes} {...listeners}>
        <SortableContext
          items={tasks.map((task) => task.id)}
          strategy={verticalListSortingStrategy}
        >
          {renderPlaceholderTask()}
          {tasks.map((task) => (
            <SortableTask key={task.id} task={task} />
          ))}
        </SortableContext>
      </div>
      <div className='mt-4'>
        <Input
          value={newTaskTitle}
          onChange={(e) => setNewTaskTitle(e.target.value)}
          placeholder='New task title'
          className='mb-2'
        />
        <Button onClick={handleAddTask} className='w-full'>
          Add New Task
        </Button>
      </div>
    </div>
  );
};

const ProjectWorkspace: React.FC = () => {
  const [taskLists, setTaskLists] = useState<TaskList[]>(mockTaskLists);

  const handleDragEnd = (event: DragOverEvent) => {
    const { active, over } = event;

    if (active && over) {
      if (active.data.current?.type == 'Task' && over.data.current?.type == 'Task') {
        const sourceList = taskLists.find((list) =>
          list.tasks.some((task) => task.id === active.id)
        );
        const targetList = taskLists.find((list) => list.tasks.some((task) => task.id === over.id));

        if (!sourceList || !targetList) return;

        const draggedTask = sourceList.tasks.find((task) => task.id === active.id);
        if (!draggedTask) return;

        if (sourceList === targetList) {
          // If source and target lists are the same, handle reordering within the same list
          const overIndex = targetList.tasks.findIndex((task) => task.id === over.id);
          const sourceIndex = targetList.tasks.findIndex((task) => task.id === active.id);
          // If the TaskList has >1 Tasks, then perform the later code
          if (sourceList.tasks.length > 1) {
            setTaskLists((prev) => {
              const updatedLists = prev.map((list) => {
                if (list.id === sourceList.id) {
                  const tasks = [...list.tasks];
                  tasks.splice(sourceIndex, 1);
                  tasks.splice(overIndex, 0, draggedTask);
                  return { ...list, tasks };
                }
                return list;
              });
              return updatedLists;
            });
          }
        } else {
          // Moving task from one list to another
          setTaskLists((prev) => {
            const updatedLists = prev.map((list) => {
              if (list.id === sourceList.id) {
                // Remove task in start col
                return { ...list, tasks: list.tasks.filter((task) => task.id !== active.id) };
              }
              if (list.id === targetList.id) {
                return { ...list, tasks: [...list.tasks, draggedTask] };
              }
              return list;
            });
            return updatedLists;
          });
        }
      }

      if (active.data.current?.type == 'Task' && over.data.current?.type == 'TaskList') {
        const sourceList = taskLists.find((list) =>
          list.tasks.some((task) => task.id === active.id)
        );
        const targetList = taskLists.find((list) => list.id === over.id);

        if (!sourceList || !targetList) return;

        const draggedTask = sourceList.tasks.find((task) => task.id === active.id);
        if (!draggedTask) return;
        if (sourceList !== targetList) {
          // Moving task from task list to task list
          setTaskLists((prev) => {
            const updatedLists = prev.map((list) => {
              if (list.id === sourceList.id) {
                return { ...list, tasks: list.tasks.filter((task) => task.id !== active.id) };
              }
              if (list.id === targetList.id) {
                return { ...list, tasks: [...list.tasks, draggedTask] };
              }
              return list;
            });
            return updatedLists;
          });
        }
      }
    }
  };

  const handleAddTaskList = () => {
    setTaskLists((prev) => [
      ...prev,
      {
        id: `task-list-${Math.random().toString(36).substr(2, 9)}`,
        name: `New Task List`,
        tasks: [],
        maxTasks: 10, // Add default value for maxTasks
        projectId: '1' // Add default value for projectId
      } as TaskList
    ]);
  };

  return (
    <div className='min-h-screen bg-gray-100 p-4'>
      <Button onClick={handleAddTaskList} className='mb-4'>
        Add New Task List
      </Button>
      <DndContext collisionDetection={closestCenter} onDragEnd={handleDragEnd}>
        <SortableContext
          items={taskLists.map((list) => list.id)}
          strategy={verticalListSortingStrategy}
        >
          <div className='flex gap-4 overflow-auto'>
            {taskLists.map((taskList) => (
              <TaskList
                key={taskList.id}
                taskList={taskList}
                tasks={taskList.tasks}
                setTasks={setTaskLists}
              />
            ))}
          </div>
        </SortableContext>
      </DndContext>
    </div>
  );
};

export default ProjectWorkspace;
