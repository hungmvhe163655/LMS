import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const disableDevice = async (deviceId: string) => {
  const response = await api.delete(`/devices/${deviceId}`);
  return response.data;
};

type UseDisableDeviceOptions = {
  mutationConfig?: MutationConfig<typeof disableDevice>;
};

export const useDisableDevice = ({ mutationConfig }: UseDisableDeviceOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: disableDevice,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({ queryKey: ['devices-list'] });
      onSuccess?.(...args);
    }
  });
};
