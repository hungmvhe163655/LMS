import moment from 'moment';
import React from 'react';

import { Button } from '@/components/ui/button';
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogFooter
} from '@/components/ui/dialog';

import { useDeleteSchedule } from '../api/delete-schedules';
import { Schedule } from '../api/get-schedules-for-device';

interface ScheduleDetailDialogProps {
  isOpen: boolean;
  onClose: () => void;
  schedule: Schedule | null;
}

const ScheduleDetailDialog: React.FC<ScheduleDetailDialogProps> = ({
  isOpen,
  onClose,
  schedule
}) => {
  const { mutate: deleteSchedule } = useDeleteSchedule({
    mutationConfig: {
      onSuccess: () => {
        onClose();
      }
    }
  });

  if (!schedule || !schedule.account) return null;

  const handleDelete = () => {
    deleteSchedule(schedule.id);
  };

  return (
    <Dialog open={isOpen} onOpenChange={onClose}>
      <DialogContent>
        <DialogHeader>
          <DialogTitle>Schedule Details</DialogTitle>
        </DialogHeader>
        <div className='space-y-2'>
          <p>
            <strong>Username:</strong> {schedule.account.userName}
          </p>
          <p>
            <strong>Full Name:</strong> {schedule.account.fullName}
          </p>
          <p>
            <strong>Phone Number:</strong> {schedule.account.phoneNumber}
          </p>
          <p>
            <strong>Email:</strong> {schedule.account.email}
          </p>
          <p>
            <strong>Start Time:</strong> {moment(schedule.startDate).format('LLL')}
          </p>
          <p>
            <strong>End Time:</strong> {moment(schedule.endDate).format('LLL')}
          </p>
          <p>
            <strong>Purpose:</strong> {schedule.purpose}
          </p>
        </div>
        <DialogFooter>
          <Button variant='destructive' onClick={handleDelete}>
            Delete Schedule
          </Button>
          <Button variant='outline' onClick={onClose}>
            Close
          </Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
};

export default ScheduleDetailDialog;
