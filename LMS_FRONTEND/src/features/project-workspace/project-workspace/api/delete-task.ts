import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const deleteTask = async (taskId: string) => {
  const response = await api.delete(`/tasks/${taskId}`);
  return response.data;
};

type UseDeleteTaskOptions = {
  mutationConfig?: MutationConfig<typeof deleteTask>;
};

export const useDeleteTask = ({ mutationConfig }: UseDeleteTaskOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: deleteTask,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({ queryKey: ['taskLists'] });
      onSuccess?.(...args);
    }
  });
};
