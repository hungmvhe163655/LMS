import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

export type Device = {
  id: string;
  name: string;
  deviceStatus: string;
  description: string;
  lastUsed: Date;
  ownedBy: string;
  isDeleted: boolean;
  filekey: string | null;
};

export const getDevicesList = async (): Promise<Device[]> => {
  const response = await api.get('/devices');
  return response.data;
};

export const getDevicesListQueryOptions = () => {
  return queryOptions({
    queryKey: ['devices-list'],
    queryFn: getDevicesList
  });
};

type UseDevicesListOptions = {
  queryConfig?: QueryConfig<typeof getDevicesListQueryOptions>;
};

export const useDevicesList = ({ queryConfig }: UseDevicesListOptions = {}) => {
  return useQuery({
    ...getDevicesListQueryOptions(),
    ...queryConfig
  });
};
