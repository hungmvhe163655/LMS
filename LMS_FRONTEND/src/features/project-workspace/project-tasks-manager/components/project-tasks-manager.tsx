import { useState } from 'react';

import { Task } from '@/features/project-workspace/project-workspace/types/project-types';

import ListOfTask from './list-of-tasks';
import TaskDetail from './task-details';

const ProjectTaskManager = () => {
  const [selectedTask, setSelectedTask] = useState<Task | null>(null);

  const handleTaskClick = (task: Task) => {
    setSelectedTask(task);
  };

  return (
    <div className='flex'>
      <ListOfTask onTaskClick={handleTaskClick} />
      {selectedTask && <TaskDetail task={selectedTask} />}
    </div>
  );
};

export default ProjectTaskManager;
