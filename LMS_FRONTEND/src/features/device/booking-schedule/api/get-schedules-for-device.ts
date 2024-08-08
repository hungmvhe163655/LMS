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
  dateInput: string,
  timeFrame: string // Add timeFrame parameter
): Promise<Schedule[]> => {
  const response = await api.get(`/schedules/devices/${deviceId}`, {
    params: { dateInput: dateInput, TimeFrame: timeFrame }
  });
  return response.data;
};

type UseSchedulesForDeviceOptions = {
  deviceId: string;
  dateInput: string;
  timeFrame: string; // Add timeFrame parameter
  queryConfig?: QueryConfig<typeof getSchedulesForDevice>;
};

export const useSchedulesForDevice = ({
  deviceId,
  dateInput,
  timeFrame,
  queryConfig
}: UseSchedulesForDeviceOptions) => {
  return useQuery({
    queryKey: ['schedules-for-device', deviceId, dateInput, timeFrame],
    queryFn: () => getSchedulesForDevice(deviceId, dateInput, timeFrame),
    ...queryConfig
  });
};
