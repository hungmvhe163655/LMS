import React from 'react';
import OngoingProjects from '@/components/ui/ongoing-projects';
import CurrentTasks from '@/components/ui/current-tasks';
import ImportantNotifications from '@/components/ui/important-notifications';

const StudentDashboard: React.FC = () => {
  const ongoingProjects = {
    name: 'Lab Management System',
    supervisor: 'Mrs. Chi',
    tasksUndone: 5
  };

  const currentTasks = [
    'Implement code for project listing',
    'Fix supervisor register function',
    'Finish report 4'
  ];

  const notifications = [
    { date: '08/06/2024', message: 'You are added to project LAB MANAGEMENT SYSTEM', type: 'info' },
    {
      date: '07/06/2024',
      message: 'You are requested to exit project Blockchain Pokemon',
      type: 'alert'
    }
  ];

  return (
    <div className='min-h-screen bg-gray-100 p-6'>
      <header className='mb-4'>{/* Your existing header component */}</header>
      <div className='grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6'>
        <OngoingProjects {...ongoingProjects} />
        <CurrentTasks tasks={currentTasks} />
        <ImportantNotifications notifications={notifications} />
      </div>
    </div>
  );
};

export default StudentDashboard;
