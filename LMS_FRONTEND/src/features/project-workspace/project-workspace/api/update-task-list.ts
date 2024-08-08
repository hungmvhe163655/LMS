import { useMutation, useQueryClient } from '@tanstack/react-query';
import { useParams } from 'react-router-dom';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { taskListKeys } from '../utils/queries';

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
  const { projectId } = useParams() as { projectId: string };
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: updateTaskList,
    onSuccess: (data, variables, context) => {
      queryClient.invalidateQueries({ queryKey: taskListKeys.all });
      console.log(projectId);
      onSuccess?.(data, variables, context);
    }
  });
};
