import { User } from '@/types/api';

export function StudentDetail({ user }: { user: User | undefined }) {
  return (
    <div className='flex space-y-2'>
      <div className='flex flex-col space-y-0 lg:space-y-3'>
        <span className='text-gray-600'>
          <span className='font-bold'> Roll Number:</span> {user?.rollNumber}
        </span>
        <span className='text-gray-600'>
          <span className='font-bold'> Major:</span> {user?.major}
        </span>
        <span className='text-gray-600'>
          <span className='font-bold'>Specialized:</span> {user?.specialized}
        </span>
      </div>
    </div>
  );
}
