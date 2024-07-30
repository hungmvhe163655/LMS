import React from 'react';

interface ScheduleOverlayProps {
  schedule: {
    id: string;
    deviceId: string;
    accountId: string;
    scheduledDate: Date;
    startDate: Date;
    endDate: Date;
    purpose: string;
  };
}

const ScheduleOverlay: React.FC<ScheduleOverlayProps> = ({ schedule }) => {
  return <div className='absolute inset-0 z-20 bg-blue-200'>{schedule.purpose}</div>;
};

export default ScheduleOverlay;
