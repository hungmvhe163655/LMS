import { useState } from 'react';
import { FaEdit } from 'react-icons/fa';

import { Avatar, AvatarImage } from '@/components/ui/avatar';
import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger
} from '@/components/ui/dialog';
import useAvatar from '@/hooks/use-avatar';
import { useCurrentLoginUser } from '@/hooks/use-current-login-user';
import { User } from '@/types/api';
import { ROLES } from '@/types/constant';

import { EditProfileForm } from './edit-profile-form';
import { StudentDetail } from './student-detail';

export function Info() {
  const { data: user, isLoading } = useCurrentLoginUser();
  const [open, setOpen] = useState(false);
  const role = user?.roles[0];
  const isStudent = user?.roles.includes(ROLES.STUDENT);
  const url = useAvatar(user?.id as string);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <div className='mx-auto flex max-w-4xl rounded-lg bg-white p-10 shadow-md'>
      <div className='w-full lg:flex lg:justify-between'>
        <div className='flex flex-col lg:w-full lg:flex-row'>
          {/* First Column */}
          <div className='lg:w-1/2'>
            <div className='flex flex-col space-y-4 lg:flex-row'>
              <Avatar className='my-auto mr-4 size-32 text-4xl font-bold'>
                <AvatarImage src={url} />
              </Avatar>
              <div className='my-auto flex flex-col space-y-1'>
                <span className='text-xl font-bold'>{user?.fullName}</span>
                <span className='italic text-gray-600'>{role}</span>
                <span className='text-sm text-gray-500 '>{user?.gender}</span>
              </div>
            </div>
          </div>

          {/* Second Column */}
          <div className='my-auto lg:w-1/2'>{isStudent && <StudentDetail user={user} />}</div>
        </div>
        <div className='mt-2'>
          <Dialog open={open} onOpenChange={setOpen}>
            <DialogTrigger asChild>
              <Button className='flex w-full items-center justify-center rounded-lg bg-blue-500 p-3 text-white hover:bg-blue-600 lg:w-auto'>
                Edit <FaEdit className='ml-2' />
              </Button>
            </DialogTrigger>
            <DialogContent>
              <DialogHeader>
                <DialogTitle>Edit profile</DialogTitle>
                <DialogDescription>Make changes to your profile here.</DialogDescription>
              </DialogHeader>
              <EditProfileForm user={user as User} onSubmitForm={setOpen} />
            </DialogContent>
          </Dialog>
        </div>
      </div>
    </div>
  );
}
