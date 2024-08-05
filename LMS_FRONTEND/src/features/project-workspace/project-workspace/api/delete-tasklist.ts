import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const deleteTaskList = async (taskListId: string) => {
  const response = await api.delete(`/task-lists/${taskListId}`);
  return response.data;
};

type UseDeleteTaskListOptions = {
  mutationConfig?: MutationConfig<typeof deleteTaskList>;
};

export const useDeleteTaskList = ({ mutationConfig }: UseDeleteTaskListOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: deleteTaskList,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({ queryKey: ['taskLists'] });
      onSuccess?.(...args);
    }
  });
};
