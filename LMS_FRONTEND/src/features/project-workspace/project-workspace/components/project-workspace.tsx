import { DndContext, closestCenter, DragOverEvent, useSensor, useSensors } from '@dnd-kit/core';
import { SortableContext, horizontalListSortingStrategy } from '@dnd-kit/sortable';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import { Button } from '@/components/ui/button';

import { getTaskLists } from '../api/get-tasklists';
import type { TaskList as TaskListType } from '../types/project-types';

import { MouseSensor, KeyboardSensor } from './customer-sensors'; // Import the custom sensors
import SortableTaskList from './sortable-tasklist';

const ProjectWorkspace: React.FC = () => {
  const { projectId } = useParams<{ projectId: string }>();
  const [taskLists, setTaskLists] = useState<TaskListType[]>([]);
  const [isDialogOpen, setIsDialogOpen] = useState(false); // Track if dialog is open
  const mouseSensor = useSensor(MouseSensor);
  const keyboardSensor = useSensor(KeyboardSensor);
  const sensors = useSensors(mouseSensor, keyboardSensor);

  useEffect(() => {
    if (projectId) {
      getTaskLists(projectId).then((data) => setTaskLists(data));
    }
  }, [projectId]);

  const handleDragEnd = (event: DragOverEvent) => {
    const { active, over } = event;

    if (active && over) {
      if (active.data.current?.type === 'Task' && over.data.current?.type === 'Task') {
        const sourceList = taskLists.find((list) =>
          list.tasks.some((task) => task.id === active.id)
        );
        const targetList = taskLists.find((list) => list.tasks.some((task) => task.id === over.id));

        if (!sourceList || !targetList) return;

        const draggedTask = sourceList.tasks.find((task) => task.id === active.id);
        if (!draggedTask) return;

        if (sourceList === targetList) {
          const overIndex = targetList.tasks.findIndex((task) => task.id === over.id);
          const sourceIndex = targetList.tasks.findIndex((task) => task.id === active.id);

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

      if (active.data.current?.type === 'Task' && over.data.current?.type === 'TaskList') {
        const sourceList = taskLists.find((list) =>
          list.tasks.some((task) => task.id === active.id)
        );
        const targetList = taskLists.find((list) => list.id === over.id);

        if (!sourceList || !targetList) return;

        const draggedTask = sourceList.tasks.find((task) => task.id === active.id);
        if (!draggedTask) return;

        if (sourceList !== targetList) {
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

      if (active.data.current?.type === 'TaskList' && over.data.current?.type === 'TaskList') {
        const sourceIndex = taskLists.findIndex((list) => list.id === active.id);
        const targetIndex = taskLists.findIndex((list) => list.id === over.id);

        setTaskLists((prev) => {
          const updatedLists = [...prev];
          const [movedList] = updatedLists.splice(sourceIndex, 1);
          updatedLists.splice(targetIndex, 0, movedList);
          return updatedLists;
        });
      }
    }
  };

  const handleAddTaskList = () => {
    setTaskLists((prev) => [
      ...prev,
      {
        id: `task-list-${Math.random().toString(36).substr(2, 9)}`,
        name: 'New Task List',
        tasks: [],
        maxTasks: 10, // Add default value for maxTasks
        projectId: projectId || '', // Add projectId from params
        order: prev.length + 1 // Add order based on the current number of task lists
      } as TaskListType
    ]);
  };

  return (
    <div className='h-fit min-h-screen bg-gray-100 p-4'>
      <h1 className='mb-4 text-2xl font-bold'>Project Workspace</h1>
      <p className='text-lg font-medium'>ID in the workspace: {projectId}</p>
      <Button onClick={handleAddTaskList} className='mb-4'>
        Add New Task List
      </Button>
      <DndContext collisionDetection={closestCenter} onDragEnd={handleDragEnd} sensors={sensors}>
        <SortableContext
          items={taskLists.map((list) => list.id)}
          strategy={horizontalListSortingStrategy}
          disabled={isDialogOpen} // Disable sorting if dialog is open
        >
          <div className='flex gap-4 overflow-auto'>
            {taskLists.map((taskList) => (
              <SortableTaskList
                key={taskList.id}
                taskList={taskList}
                tasks={taskList.tasks}
                setTasks={setTaskLists}
                setIsDialogOpen={setIsDialogOpen} // Pass the state setter to children
              />
            ))}
          </div>
        </SortableContext>
      </DndContext>
    </div>
  );
};

export default ProjectWorkspace;
