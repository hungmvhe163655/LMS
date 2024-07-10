import React from 'react';

import { Button } from '@/components/ui/button';

const LabOverallReport: React.FC = () => {
  // Placeholder variables for data. Replace with API data when available.
  const numMembers = 100;
  const activeProjects = 5;
  const numDevices = 21;

  return (
    <div className='rounded-md bg-blue-100 p-4 shadow-md'>
      <h2 className='mb-4 text-xl font-semibold'>Lab Overall Report</h2>
      <p className='mb-2'>
        Number of members: <strong>{numMembers}</strong>
      </p>
      <p className='mb-2'>
        Active projects: <strong>{activeProjects}</strong>
      </p>
      <p className='mb-4'>
        Number of devices: <strong>{numDevices}</strong>
      </p>
      <Button className='mb-2 w-full'>Manage Accounts</Button>
      <Button className='w-full'>Add Accounts</Button>
    </div>
  );
};

export default LabOverallReport;
