import React from 'react';

import ActiveProject from '@/components/app/active-projects';
import ImportantNotifications from '@/components/app/important-notifications';
import TaskOverallChart from '@/components/app/task-overall-chart';
import TaskVerifyingRequest from '@/components/app/task-verifying-request';

const SupervisorDashboard: React.FC = () => {
  const notifications = [
    { date: '08/06/2024', message: 'You are added to project LAB MANAGEMENT SYSTEM', type: 'info' },
    {
      date: '07/06/2024',
      message: 'You are requested to exit project Blockchain Pokemon',
      type: 'alert'
    }
  ];

  return (
    <div className='grid grid-cols-1 gap-4 p-4 md:grid-cols-2 lg:grid-cols-2'>
      <ActiveProject />
      <ImportantNotifications notifications={notifications} />
      <TaskVerifyingRequest />
      <TaskOverallChart />
    </div>
  );
};

export default SupervisorDashboard;
