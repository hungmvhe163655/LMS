import { DndContext, closestCenter, DragOverEvent, useSensor, useSensors } from '@dnd-kit/core';
import { SortableContext, horizontalListSortingStrategy } from '@dnd-kit/sortable';
import React, { useState } from 'react';

import { Button } from '@/components/ui/button';

import { mockTaskLists } from '../mock-tasks';
import type { TaskList as TaskListType } from '../types/workspace-types';

import { MouseSensor, KeyboardSensor } from './customer-sensors'; // Import the custom sensors
import SortableTaskList from './sortable-tasklist';

const ProjectWorkspace: React.FC = () => {
  const [taskLists, setTaskLists] = useState<TaskListType[]>(mockTaskLists);
  const mouseSensor = useSensor(MouseSensor);
  const keyboardSensor = useSensor(KeyboardSensor);
  const sensors = useSensors(mouseSensor, keyboardSensor);

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
        projectId: '1' // Add default value for projectId
      } as TaskListType
    ]);
  };

  return (
    <div className='min-h-screen bg-gray-100 p-4'>
      <Button onClick={handleAddTaskList} className='mb-4'>
        Add New Task List
      </Button>
      <DndContext collisionDetection={closestCenter} onDragEnd={handleDragEnd} sensors={sensors}>
        <SortableContext
          items={taskLists.map((list) => list.id)}
          strategy={horizontalListSortingStrategy}
        >
          <div className='flex gap-4 overflow-auto'>
            {taskLists.map((taskList) => (
              <SortableTaskList
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
