import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';

export type AddDevicePayload = {
  name: string;
  description: string;
};

export const addDevice = async (payload: AddDevicePayload): Promise<void> => {
  await api.post('/devices', payload);
};

export const useAddDevice = () => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: addDevice,
    onSuccess: () => {
      queryClient.invalidateQueries({ queryKey: ['devices-list'] }); // Correct query key
    }
  });
};
