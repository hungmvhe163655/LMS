import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const updateTaskList = async ({
  taskId,
  srcTaskListId,
  overTaskListId
}: {
  taskId: string;
  srcTaskListId: string;
  overTaskListId: string;
}) => {
  const response = await api.patch(
    `/task-lists/${srcTaskListId}/tasks/${taskId}`,
    [
      {
        op: 'replace',
        path: '/TaskListId',
        value: overTaskListId
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

type UseUpdateTaskListOptions = {
  mutationConfig?: MutationConfig<typeof updateTaskList>;
};

export const useUpdateTaskList = ({ mutationConfig }: UseUpdateTaskListOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: updateTaskList,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({ queryKey: ['taskLists'] });
      onSuccess?.(...args);
    }
  });
};
