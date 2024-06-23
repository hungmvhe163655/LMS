import React from 'react';
import { Link } from 'react-router-dom';

const ListNews: React.FC = () => {
  return (
    <div className='flex flex-col items-center'>
      <div className='flex w-full justify-between bg-white p-4 shadow'>
        <div className='flex items-center gap-2'>
          <input type='text' placeholder='Search news' className='border rounded px-2 py-1' />
          <button className='p-2'>🔍</button>
          <button className='bg-blue-500 text-white px-4 py-2 rounded'>
            <Link to={'/news/create'}>Create News</Link>
          </button>
        </div>
      </div>
      <main className='mt-8 w-4/5'>
        <h1 className='mb-6 text-3xl font-bold'>List News</h1>
        <div className='space-y-4'>
          {[...Array(4)].map((_, index) => (
            <div
              key={index}
              className='flex items-center justify-between rounded bg-white p-4 shadow'
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
