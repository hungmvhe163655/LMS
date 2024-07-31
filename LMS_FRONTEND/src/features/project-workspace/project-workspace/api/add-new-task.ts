import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { authStore } from '@/lib/auth-store';
import { MutationConfig } from '@/lib/react-query';

const { accessData } = authStore.getState();
const userId = accessData?.id;

export const addNewTask = async ({
  title,
  taskListId,
  projectId
}: {
  title: string;
  taskListId: string;
  projectId: string | undefined;
}) => {
  const response = await api.post('/tasks', {
    title,
    createdBy: userId,
    requiredValidation: true,
    description: title,
    taskPriority: 'Low',
    taskListId,
    projectId,
    taskStatus: 'Open/To do'
  });
  return response.data;
};

type UseAddNewTaskOptions = {
  mutationConfig?: MutationConfig<typeof addNewTask>;
};

export const useAddNewTask = ({ mutationConfig }: UseAddNewTaskOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: addNewTask,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({ queryKey: ['taskLists'] });
      onSuccess?.(...args);
    }
  });
};
