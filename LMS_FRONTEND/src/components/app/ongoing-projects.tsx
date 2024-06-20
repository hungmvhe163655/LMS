import React from 'react';

interface ProjectProps {
  name: string;
  supervisor: string;
  tasksUndone: number;
}

const OngoingProjects: React.FC<ProjectProps> = ({ name, supervisor, tasksUndone }) => {
  return (
    <div className='rounded-lg bg-blue-100 p-4 shadow-md'>
      <h2 className='mb-2 text-xl font-bold'>{name}</h2>
      <p className='text-gray-700'>Supervisor: {supervisor}</p>
      <p className='text-gray-700'>Tasks undone: {tasksUndone}</p>
      <button className='mt-2 rounded-lg bg-blue-500 px-4 py-2 text-white'>
        View your projects
      </button>
    </div>
  );
};

export default OngoingProjects;
