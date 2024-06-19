import React from 'react';
import { Link } from 'react-router-dom';

const ListNews: React.FC = () => {
  return (
    <div className='flex flex-col items-center'>
      <div className='flex justify-between w-full p-4 bg-white shadow'>
        <div className='flex items-center gap-2'>
          <input type='text' placeholder='Search news' className='border rounded px-2 py-1' />
          <button className='p-2'>🔍</button>
          <button className='bg-blue-500 text-white px-4 py-2 rounded'>
            <Link to={'/news/create'}>Create News</Link>
          </button>
        </div>
      </div>
      <main className='w-4/5 mt-8'>
        <h1 className='text-3xl font-bold mb-6'>List News</h1>
        <div className='space-y-4'>
          {[...Array(4)].map((_, index) => (
            <div
              key={index}
              className='flex justify-between items-center p-4 bg-white shadow rounded'
            >
              <div>
                <h2 className='text-xl font-semibold'>News Title</h2>
                <p className='text-gray-500'>01-01-2024 | User</p>
              </div>
              <div className='flex gap-2'>
                <button className='text-blue-500'>✏️</button>
                <button className='text-red-500'>🗑️</button>
              </div>
            </div>
          ))}
        </div>
      </main>
    </div>
  );
};

export default ListNews;
