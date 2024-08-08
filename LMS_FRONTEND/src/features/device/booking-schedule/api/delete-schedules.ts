import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const deleteSchedule = async (scheduleId: string) => {
  const response = await api.delete(`/schedules/${scheduleId}`);
  return response.data;
};

type UseDeleteScheduleOptions = {
  mutationConfig?: MutationConfig<typeof deleteSchedule>;
};

export const useDeleteSchedule = ({ mutationConfig }: UseDeleteScheduleOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: deleteSchedule,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({ queryKey: ['schedules-for-device'] });
      onSuccess?.(...args);
    }
  });
};
