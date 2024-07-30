import React from 'react';
import { Link } from 'react-router-dom';

interface TaskProps {
  tasks: string[];
}

const CurrentTasks: React.FC<TaskProps> = ({ tasks }) => {
  return (
    <div className='rounded-lg bg-blue-100 p-4 shadow-md'>
      <h2 className='mb-2 text-xl font-bold'>Current Tasks</h2>
      {tasks.map((task, index) => (
        <div key={index} className='mb-2 flex items-center justify-between'>
          <span>{task}</span>
          <button className='rounded-lg bg-blue-500 px-2 py-1 text-white'>Go</button>
        </div>
      ))}
      <Link to={'/project/tasks'}>
        {' '}
        <button className='mt-2 rounded-lg bg-blue-500 px-4 py-2 text-white'>View all tasks</button>
      </Link>
    </div>
  );
};

export default CurrentTasks;
