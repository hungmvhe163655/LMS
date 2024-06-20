import React from 'react';

interface TaskProps {
  tasks: string[];
}

const CurrentTasks: React.FC<TaskProps> = ({ tasks }) => {
  return (
    <div className='bg-blue-100 p-4 rounded-lg shadow-md'>
      <h2 className='text-xl font-bold mb-2'>Current Tasks</h2>
      {tasks.map((task, index) => (
        <div key={index} className='flex justify-between items-center mb-2'>
          <span>{task}</span>
          <button className='px-2 py-1 bg-blue-500 text-white rounded-lg'>Go</button>
        </div>
      ))}
      <button className='mt-2 px-4 py-2 bg-blue-500 text-white rounded-lg'>View all tasks</button>
    </div>
  );
};

export default CurrentTasks;
