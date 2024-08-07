import { DndContext, closestCenter, DragEndEvent, useSensor, useSensors } from '@dnd-kit/core';
import { SortableContext, horizontalListSortingStrategy } from '@dnd-kit/sortable';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import { Button } from '@/components/ui/button';

import { addNewTaskList } from '../api/add-new-tasklist'; // Import the addNewTaskList function
import { useChangeTaskOrder } from '../api/change-task-order';
import { getTaskLists } from '../api/get-tasklists';
import { useUpdateTaskList } from '../api/move-task';
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

  const queryClient = useQueryClient();

  const { mutate: updateTaskListMutate } = useUpdateTaskList({
    mutationConfig: {
      onSuccess: () => {
        queryClient.invalidateQueries({ queryKey: ['taskLists', projectId] });
      }
    }
  });

  const addTaskListMutation = useMutation({
    mutationFn: addNewTaskList,
    onSuccess: (newTaskList) => {
      queryClient.invalidateQueries({ queryKey: ['taskLists', projectId] });
      setTaskLists((prev) => [...prev, newTaskList]);
    },
    onError: (error) => {
      console.error('Error adding task list:', error);
    }
  });

  useEffect(() => {
    if (projectId) {
      getTaskLists(projectId).then((data) => setTaskLists(data));
    }
  }, [projectId]);

  const { mutate: changeTaskOrderMutate } = useChangeTaskOrder({
    mutationConfig: {
      onSuccess: () => {
        queryClient.invalidateQueries({ queryKey: ['taskLists', projectId] });
      }
    }
  });

  const handleDragEnd = (event: DragEndEvent) => {
    const { active, over } = event;

    if (active && over) {
      // Task on Task
      if (active.data.current?.type === 'Task' && over.data.current?.type === 'Task') {
        const sourceList = taskLists?.find((list) =>
          list.tasks.some((task) => task.id === active.id)
        );
        const targetList = taskLists?.find((list) =>
          list.tasks.some((task) => task.id === over.id)
        );

        if (!sourceList || !targetList) return;

        const draggedTask = sourceList.tasks.find((task) => task.id === active.id);
        if (!draggedTask) return;

        // Task on Task of the same column

        if (sourceList === targetList) {
          const overIndex = targetList.tasks.findIndex((task) => task.id === over.id);
          const sourceIndex = targetList.tasks.findIndex((task) => task.id === active.id);

          if (sourceList.tasks.length > 1) {
            changeTaskOrderMutate({
              taskListId: sourceList.id,
              taskId: draggedTask.id,
              order: over.data.current?.order
            });
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
          // Task on Task of a different column
          updateTaskListMutate({
            taskId: draggedTask.id,
            srcTaskListId: sourceList.id,
            overTaskListId: targetList.id
          });
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
      // Task on TaskList
      if (active.data.current?.type === 'Task' && over.data.current?.type === 'TaskList') {
        const sourceList = taskLists?.find((list) =>
          list.tasks.some((task) => task.id === active.id)
        );
        const targetList = taskLists?.find((list) => list.id === over.id);

        if (!sourceList || !targetList) return;

        const draggedTask = sourceList.tasks.find((task) => task.id === active.id);
        if (!draggedTask) return;
        // Task on a different TaskList
        if (sourceList !== targetList) {
          updateTaskListMutate({
            taskId: draggedTask.id,
            srcTaskListId: sourceList.id,
            overTaskListId: targetList.id
          });
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
      // TaskList on TaskList
      if (active.data.current?.type === 'TaskList' && over.data.current?.type === 'TaskList') {
        const sourceIndex = taskLists?.findIndex((list) => list.id === active.id);
        const targetIndex = taskLists?.findIndex((list) => list.id === over.id);

        setTaskLists((prev) => {
          const updatedLists = [...prev];
          const [movedList] = updatedLists.splice(sourceIndex!, 1);
          updatedLists.splice(targetIndex!, 0, movedList);
          return updatedLists;
        });
      }
    }
  };

  const handleAddTaskList = () => {
    addTaskListMutation.mutate({
      name: 'New Task List',
      maxTasks: 10,
      projectId: projectId || ''
    });
  };

  return (
    <div className='w-full overflow-x-auto bg-gray-100 p-4'>
      <h1 className='mb-4 text-2xl font-bold'>Project Workspace</h1>
      <p className='text-lg font-medium'>ID in the workspace: {projectId}</p>
      <Button onClick={handleAddTaskList} className='mb-4'>
        Add New Task List
      </Button>

      <DndContext collisionDetection={closestCenter} onDragEnd={handleDragEnd} sensors={sensors}>
        <SortableContext
          items={taskLists?.map((list) => list.id) || []}
          strategy={horizontalListSortingStrategy}
          disabled={isDialogOpen} // Disable sorting if dialog is open
        >
          <ol className='flex min-w-fit flex-1 gap-4 md:max-h-[60dvh] lg:max-h-[70dvh]'>
            {taskLists?.map((taskList) => (
              <SortableTaskList
                key={taskList.id}
                taskList={taskList}
                tasks={taskList.tasks}
                setTasks={setTaskLists}
                setIsDialogOpen={setIsDialogOpen}
                projectId={projectId?.toString()}
              />
            ))}
          </ol>
        </SortableContext>
      </DndContext>
    </div>
  );
};

export default ProjectWorkspace;
