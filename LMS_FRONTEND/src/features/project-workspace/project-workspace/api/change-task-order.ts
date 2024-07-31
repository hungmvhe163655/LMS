import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const changeTaskOrder = async ({
  taskListId,
  taskId,
  order
}: {
  taskListId: string;
  taskId: string;
  order: number;
}) => {
  const response = await api.patch(
    `/task-lists/${taskListId}/tasks/${taskId}/move`,
    [
      {
        op: 'replace',
        path: '/Order',
        value: order
      }
    ],
    {
      headers: {
        'Content-Type': 'application/json-patch+json'
      }
    }
  );
  return response.data;
};

type UseChangeTaskOrderOptions = {
  mutationConfig?: MutationConfig<typeof changeTaskOrder>;
};

export const useChangeTaskOrder = ({ mutationConfig }: UseChangeTaskOrderOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: changeTaskOrder,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({ queryKey: ['taskLists'] });
      onSuccess?.(...args);
    }
  });
};
