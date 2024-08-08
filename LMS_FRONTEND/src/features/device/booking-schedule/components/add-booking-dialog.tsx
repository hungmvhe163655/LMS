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

import { useAddBooking } from '../api/add-schedule';

const schema = z.object({
  startDate: z.string().nonempty('Start Date is required'),
  endDate: z.string().nonempty('End Date is required'),
  purpose: z.string().nonempty('Purpose is required')
});

type AddBookingFormValues = z.infer<typeof schema>;

const AddBookingDialog: React.FC<{ deviceId: string; accountId: string }> = ({
  deviceId,
  accountId
}) => {
  const { control, handleSubmit, reset } = useForm<AddBookingFormValues>({
    resolver: zodResolver(schema)
  });

  const { mutate: addBooking, isError, isSuccess } = useAddBooking();

  const onSubmit = (data: AddBookingFormValues) => {
    addBooking(
      {
        deviceId,
        accountId,
        startDate: data.startDate,
        endDate: data.endDate,
        purpose: data.purpose
      },
      {
        onSuccess: () => {
          reset();
        }
      }
    );
  };

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button className='mb-4'>Add Booking</Button>
      </DialogTrigger>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Add Booking</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit(onSubmit)} className='space-y-4'>
          <div>
            <Label htmlFor='startDate'>Start Date</Label>
            <Controller
              name='startDate'
              control={control}
              render={({ field }) => <Input type='datetime-local' id='startDate' {...field} />}
            />
          </div>
          <div>
            <Label htmlFor='endDate'>End Date</Label>
            <Controller
              name='endDate'
              control={control}
              render={({ field }) => <Input type='datetime-local' id='endDate' {...field} />}
            />
          </div>
          <div>
            <Label htmlFor='purpose'>Purpose</Label>
            <Controller
              name='purpose'
              control={control}
              render={({ field }) => <Input id='purpose' {...field} />}
            />
          </div>
          {isError && <p className='text-red-500'>Error adding booking</p>}
          {isSuccess && <p className='text-green-500'>Booking added successfully</p>}
          <DialogFooter>
            <Button variant='outline' onClick={() => reset()}>
              Cancel
            </Button>
            <Button type='submit'>Add Booking</Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
};

export default AddBookingDialog;
