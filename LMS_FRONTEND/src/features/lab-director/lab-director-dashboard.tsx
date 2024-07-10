import React from 'react';

import ImportantNotifications from '@/components/app/important-notifications';
import LabOverallReport from '@/components/app/lab-overall-report';
import MemberReportChart from '@/components/app/member-report-chart';

const LabDirectorDashboard: React.FC = () => {
  const notifications = [
    {
      date: '08/06/2024',
      message: 'Ngo Tung Son requested to create a supervisor account.',
      type: 'info'
    },
    {
      date: '07/06/2024',
      message: 'Le Phuong Chi created project: Lab Management System',
      type: 'info'
    },
    {
      date: '06/06/2024',
      message: 'Le Phuong Chi changed Grab 3.0’s status to Finished.',
      type: 'info'
    },
    {
      date: '05/06/2024',
      message: 'Le Phuong Chi changed Blockchain Pokemon’s status to Cancelled.',
      type: 'alert'
    }
  ];

  return (
    <div className='grid grid-cols-1 gap-4 p-4 md:grid-cols-2 lg:grid-cols-2'>
      <LabOverallReport />
      <ImportantNotifications notifications={notifications} />
      <MemberReportChart />
    </div>
  );
};

export default LabDirectorDashboard;
