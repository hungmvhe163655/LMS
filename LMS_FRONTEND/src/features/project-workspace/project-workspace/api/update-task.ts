import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export interface UpdateTaskPayload {
  id: string;
  title: string;
  requiredValidation: boolean;
  description: string;
  startDate: string;
  dueDate: string;
  taskPriority: string;
  taskStatus: string;
  assignedTo?: string;
}

export const updateTask = async (payload: UpdateTaskPayload): Promise<void> => {
  const { id, ...data } = payload;
  await api.put(`/tasks/${id}`, data);
};

type UseUpdateTaskOptions = {
  mutationConfig?: MutationConfig<typeof updateTask>;
};

export const useUpdateTask = ({ mutationConfig }: UseUpdateTaskOptions = {}) => {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn: updateTask,
    onSuccess: (data, ...args) => {
      queryClient.invalidateQueries({ queryKey: ['task-lists'] });
      mutationConfig?.onSuccess?.(data, ...args);
    },
    ...mutationConfig
  });
};
