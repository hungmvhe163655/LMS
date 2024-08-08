import { zodResolver } from '@hookform/resolvers/zod';
import React from 'react';
import { useForm, Controller } from 'react-hook-form';
import * as z from 'zod';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
  DialogFooter
} from '@/components/ui/dialog';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';

import { useAddDevice } from '../api/add-device';

const schema = z.object({
  name: z.string().nonempty('Name is required'),
  description: z.string().nonempty('Description is required')
});

type AddDeviceFormValues = z.infer<typeof schema>;

const AddDeviceDialog: React.FC = () => {
  const { control, handleSubmit, reset } = useForm<AddDeviceFormValues>({
    resolver: zodResolver(schema)
  });

  const { mutate: addDevice, isError, isSuccess } = useAddDevice();

  const onSubmit = (data: AddDeviceFormValues) => {
    addDevice(data, {
      onSuccess: () => {
        reset();
      }
    });
  };

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button className='mb-4'>Add Device</Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Add Device</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit(onSubmit)} className='space-y-4'>
          <div>
            <Label htmlFor='name'>Name</Label>
            <Controller
              name='name'
              control={control}
              render={({ field }) => <Input id='name' {...field} />}
            />
          </div>
          <div>
            <Label htmlFor='description'>Description</Label>
            <Controller
              name='description'
              control={control}
              render={({ field }) => <Input id='description' {...field} />}
            />
          </div>
          {isError && <p className='text-red-500'>Error adding device</p>}
          {isSuccess && <p className='text-green-500'>Device added successfully</p>}
          <DialogFooter>
            <Button type='submit'>Add device</Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
};

export default AddDeviceDialog;
