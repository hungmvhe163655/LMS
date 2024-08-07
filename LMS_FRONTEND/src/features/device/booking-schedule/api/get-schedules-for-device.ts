import { useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

export type Schedule = {
  id: string;
  deviceId: string;
  startDate: string;
  endDate: string;
  purpose: string;
  account: {
    id: string;
    userName: string;
    phoneNumber: string;
    fullName: string;
    email: string;
  };
};

export const getSchedulesForDevice = async (
  deviceId: string,
  dateInput: string
): Promise<Schedule[]> => {
  const response = await api.get(`/schedules/devices/${deviceId}`, {
    params: { dateInput: dateInput }
  });
  return response.data;
};

type UseSchedulesForDeviceOptions = {
  deviceId: string;
  dateInput: string;
  queryConfig?: QueryConfig<typeof getSchedulesForDevice>;
};

export const useSchedulesForDevice = ({
  deviceId,
  dateInput,
  queryConfig
}: UseSchedulesForDeviceOptions) => {
  return useQuery({
    queryKey: ['schedules-for-device', deviceId, dateInput],
    queryFn: () => getSchedulesForDevice(deviceId, dateInput),
    ...queryConfig
  });
};
