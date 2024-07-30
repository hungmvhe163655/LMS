import React, { useState } from 'react';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter
} from '@/components/ui/dialog';
import { Input } from '@/components/ui/input';
import { Label } from '@/components/ui/label';
import { Textarea } from '@/components/ui/textarea';

interface ScheduleFormProps {
  show: boolean;
  handleClose: () => void;
  handleSave: (schedule: Schedule) => void;
}

interface Schedule {
  id: string;
  deviceId: string;
  accountId: string;
  scheduledDate: Date;
  startDate: Date;
  endDate: Date;
  purpose: string;
}

const BookingForm: React.FC<ScheduleFormProps> = ({ show, handleClose, handleSave }) => {
  const [formData, setFormData] = useState<Schedule>({
    id: '',
    deviceId: '',
    accountId: '',
    scheduledDate: new Date(),
    startDate: new Date(),
    endDate: new Date(),
    purpose: ''
  });

  const handleChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;

    if (name === 'startDate' || name === 'endDate') {
      setFormData({ ...formData, [name]: new Date(value) });
    } else {
      setFormData({ ...formData, [name]: value });
    }
  };

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    handleSave({ ...formData, id: `id-${Date.now()}` }); // Generate a unique ID based on the current timestamp
    handleClose();
  };

  return (
    <Dialog open={show} onOpenChange={handleClose}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>New Schedule</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit}>
          <div className='grid gap-4 py-4'>
            <div className='grid grid-cols-4 items-center gap-4'>
              <Label htmlFor='deviceId' className='text-right'>
                Device ID
              </Label>
              <Input
                id='deviceId'
                name='deviceId'
                value={formData.deviceId}
                onChange={handleChange}
                className='col-span-3'
                required
              />
            </div>
            <div className='grid grid-cols-4 items-center gap-4'>
              <Label htmlFor='accountId' className='text-right'>
                Account ID
              </Label>
              <Input
                id='accountId'
                name='accountId'
                value={formData.accountId}
                onChange={handleChange}
                className='col-span-3'
                required
              />
            </div>
            <div className='grid grid-cols-4 items-center gap-4'>
              <Label htmlFor='startDate' className='text-right'>
                Start Date
              </Label>
              <Input
                type='datetime-local'
                id='startDate'
                name='startDate'
                value={new Date(
                  formData.startDate.getTime() - formData.startDate.getTimezoneOffset() * 60000
                )
                  .toISOString()
                  .slice(0, 16)}
                onChange={handleChange}
                className='col-span-3'
                required
              />
            </div>
            <div className='grid grid-cols-4 items-center gap-4'>
              <Label htmlFor='endDate' className='text-right'>
                End Date
              </Label>
              <Input
                type='datetime-local'
                id='endDate'
                name='endDate'
                value={new Date(
                  formData.endDate.getTime() - formData.endDate.getTimezoneOffset() * 60000
                )
                  .toISOString()
                  .slice(0, 16)}
                onChange={handleChange}
                className='col-span-3'
                required
              />
            </div>
            <div className='grid grid-cols-4 items-center gap-4'>
              <Label htmlFor='purpose' className='text-right'>
                Purpose
              </Label>
              <Textarea
                id='purpose'
                name='purpose'
                value={formData.purpose}
                onChange={handleChange}
                className='col-span-3'
                required
              />
            </div>
          </div>
          <DialogFooter>
            <Button variant='outline' onClick={handleClose}>
              Cancel
            </Button>
            <Button type='submit'>Save changes</Button>
          </DialogFooter>
        </form>
      </DialogContent>
    </Dialog>
  );
};

export default BookingForm;
