import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { CreateFolderAPISchema } from '../types/api';
import { resourceKeys } from '../utils/queries';

export const createFolder = async (data: CreateFolderAPISchema) => {
  const res = await api.post(`/folders`, data);
  return res.data;
};

type UseCreateFolderOptions = {
  mutationConfig?: MutationConfig<typeof createFolder>;
};

export const useCreateFolder = ({ mutationConfig }: UseCreateFolderOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: createFolder,
    onSuccess: (data, variables, context) => {
      queryClient.invalidateQueries({
        queryKey: resourceKeys.content(variables.ancestorId)
      });
      onSuccess?.(data, variables, context);
    }
  });
};
