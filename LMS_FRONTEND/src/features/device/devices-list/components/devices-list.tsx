import React from 'react';
import { Link } from 'react-router-dom';

import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow
} from '@/components/ui/table';

import { useDevicesList } from '../api/get-devices-list';

const DevicesList: React.FC = () => {
  const { data: devices, isLoading, isError } = useDevicesList();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error loading devices</div>;
  }

  return (
    <div className='container mx-auto p-6'>
      <h1 className='mb-6 text-2xl font-bold'>Devices List</h1>
      <Table>
        <TableCaption>A list of available devices.</TableCaption>
        <TableHeader>
          <TableRow>
            <TableHead>Name</TableHead>
            <TableHead>Description</TableHead>
            <TableHead>Status</TableHead>
            <TableHead className='text-right'>Last Used</TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {devices?.map((device) => (
            <TableRow key={device.id}>
              <TableCell className='font-medium'>
                <Link to={`/device/booking/${device.id}`} className='text-blue-500 hover:underline'>
                  {device.name}
                </Link>
              </TableCell>
              <TableCell>{device.description}</TableCell>
              <TableCell>{device.deviceStatus}</TableCell>
              <TableCell className='text-right'>
                {new Date(device.lastUsed).toLocaleDateString()}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
};

export default DevicesList;
