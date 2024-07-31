import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const updateTaskList = async ({
  id,
  name,
  maxTasks
}: {
  id: string;
  name: string;
  maxTasks: number;
}) => {
  const response = await api.put('/task-lists', {
    id,
    name,
    maxTasks
  });
  return response.data;
};

type UseUpdateTaskListOptions = {
  mutationConfig?: MutationConfig<typeof updateTaskList>;
};

export const useUpdateTaskList = ({ mutationConfig }: UseUpdateTaskListOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: updateTaskList,
    onSuccess: (data, ...args) => {
      console.log('Mutation success, invalidating queries');
      queryClient.invalidateQueries({ queryKey: ['taskLists'] }); // Make sure the query key is correct
      onSuccess?.(data, ...args);
    }
  });
};
