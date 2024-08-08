import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { UpdateFolderFolderAPISchema } from '../types/api';
import { resourceKeys } from '../utils/queries';

export const updateFolder = async (data: UpdateFolderFolderAPISchema) => {
  const res = await api.put(`/folders/${data.id}`, data);
  return res.data;
};

type UseUpdateFolderOptions = {
  mutationConfig?: MutationConfig<typeof updateFolder>;
};

export const useUpdateFolder = ({ mutationConfig }: UseUpdateFolderOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: updateFolder,
    onSuccess: (data, variables, context) => {
      queryClient.invalidateQueries({
        queryKey: resourceKeys.contents()
      });
      onSuccess?.(data, variables, context);
    }
  });
};
