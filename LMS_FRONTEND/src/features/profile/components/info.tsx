import { FaEdit } from 'react-icons/fa';

import { Avatar, AvatarFallback } from '@/components/ui/avatar';

export function Info() {
  return (
    <div className='mx-auto flex max-w-4xl rounded-lg bg-white p-10 shadow-md'>
      <div className='w-full'>
        <div className='flex'>
          {/* First Column */}
          <div className='w-1/2'>
            <div className='flex space-y-4'>
              <Avatar className='mr-4 size-32'>
                <AvatarFallback>VH</AvatarFallback>
              </Avatar>
              <div className='my-auto flex flex-col space-y-1'>
                <span className='text-xl font-bold'>Mai Viet Hung</span>
                <span className='text-gray-600'>Student</span>
                <span className='text-gray-600'>HE163644</span>
              </div>
            </div>
          </div>

          {/* Second Column */}
          <div className='my-auto w-1/2'>
            <div className='flex space-y-2'>
              <div className='flex flex-col space-y-4'>
                <span className='text-gray-600'>
                  <span className='font-bold'> Major:</span> Computer Science
                </span>
                <span></span>
                <span className='text-gray-600'>
                  <span className='font-bold'>Specialized:</span> AI & Machine Learning
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div>
        <button className='inline-flex items-center rounded-lg bg-blue-500 p-3 text-white hover:bg-blue-600'>
          Edit <FaEdit className='ml-2' />
        </button>
      </div>
    </div>
  );
}
