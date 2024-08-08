import React from 'react';
import { Link } from 'react-router-dom';

import { Button } from '@/components/ui/button';
import {
  Table,
  TableBody,
  TableCaption,
  TableCell,
  TableHead,
  TableHeader,
  TableRow
} from '@/components/ui/table';
import { authStore } from '@/lib/auth-store';

import { useDisableDevice } from '../api/disable-device';
import { useDevicesList } from '../api/get-devices-list';

import AddDeviceDialog from './add-device-dialog';

const DevicesList: React.FC = () => {
  const { data: devices, isLoading, isError } = useDevicesList();
  const { mutate: disableDevice } = useDisableDevice();
  const { accessData } = authStore.getState();
  const roles = accessData?.roles || [];

  const hasAddDevicePermission = roles.includes('SUPERVISOR') || roles.includes('LABADMIN');

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error loading devices</div>;
  }

  const handleDisableDevice = (deviceId: string) => {
    disableDevice(deviceId);
  };

  return (
    <div className='container mx-auto p-6'>
      {hasAddDevicePermission && <AddDeviceDialog />}
      <h1 className='mb-6 text-2xl font-bold'>Devices List</h1>
      <Table>
        <TableCaption>A list of available devices.</TableCaption>
        <TableHeader>
          <TableRow>
            <TableHead>Name</TableHead>
            <TableHead>Description</TableHead>
            <TableHead>Status</TableHead>
            <TableHead className='text-right'>Last Used</TableHead>
            <TableHead className='text-right'>Actions</TableHead>
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
              <TableCell className='text-right'>
                <Button variant='destructive' onClick={() => handleDisableDevice(device.id)}>
                  Disable
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </div>
  );
};

export default DevicesList;
