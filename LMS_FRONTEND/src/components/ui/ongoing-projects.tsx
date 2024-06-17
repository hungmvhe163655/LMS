import React from 'react';

interface ProjectProps {
  name: string;
  supervisor: string;
  tasksUndone: number;
}

const OngoingProjects: React.FC<ProjectProps> = ({ name, supervisor, tasksUndone }) => {
  return (
    <div className='bg-blue-100 p-4 rounded-lg shadow-md'>
      <h2 className='text-xl font-bold mb-2'>{name}</h2>
      <p className='text-gray-700'>Supervisor: {supervisor}</p>
      <p className='text-gray-700'>Tasks undone: {tasksUndone}</p>
      <button className='mt-2 px-4 py-2 bg-blue-500 text-white rounded-lg'>
        View your projects
      </button>
    </div>
  );
};

export default OngoingProjects;
