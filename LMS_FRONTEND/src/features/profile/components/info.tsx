import { FaEdit } from 'react-icons/fa';

import { EditProfileForm } from './edit-profile-form';

import { Avatar, AvatarFallback } from '@/components/ui/avatar';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';

export function Info() {
  return (
    <div className='mx-auto flex max-w-4xl rounded-lg bg-white p-10 shadow-md'>
      <div className='w-full lg:flex lg:justify-between'>
        <div className='flex flex-col lg:w-full lg:flex-row'>
          {/* First Column */}
          <div className='lg:w-1/2'>
            <div className='flex flex-col space-y-4 lg:flex-row'>
              <Avatar className='mr-4 size-32 text-4xl font-bold'>
                <AvatarFallback>VH</AvatarFallback>
              </Avatar>
              <div className='my-auto flex flex-col space-y-1'>
                <span className='text-xl font-bold'>Mai Viet Hung</span>
                <span className='text-gray-600'>Student | Male</span>
                <span className='text-gray-600'>HE163644</span>
              </div>
            </div>
          </div>

          {/* Second Column */}
          <div className='my-auto lg:w-1/2'>
            <div className='flex space-y-2'>
              <div className='flex flex-col space-y-0 lg:space-y-4'>
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
        <div className='mt-2'>
          <Dialog>
            <DialogTrigger asChild>
              <button className='flex w-full items-center justify-center rounded-lg bg-blue-500 p-3 text-white hover:bg-blue-600 lg:w-auto'>
                Edit <FaEdit className='ml-2' />
              </button>
            </DialogTrigger>
            <DialogContent>
              <DialogHeader>
                <DialogTitle>Edit profile</DialogTitle>
                <DialogDescription>Make changes to your profile here.</DialogDescription>
              </DialogHeader>
              <EditProfileForm />
            </DialogContent>
          </Dialog>
        </div>
      </div>
    </div>
  );
}
