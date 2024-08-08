import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { resourceKeys } from '../utils/queries';

export const deleteFolder = async ({ id }: { id: string }) => {
  const res = await api.delete(`/folders/${id}`);
  return res.data;
};

type UseDeleteFolderOptions = {
  mutationConfig?: MutationConfig<typeof deleteFolder>;
};

export const useDeleteFolder = ({ mutationConfig }: UseDeleteFolderOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: deleteFolder,
    onSuccess: (data, variables, context) => {
      queryClient.invalidateQueries({
        queryKey: resourceKeys.contents()
      });
      onSuccess?.(data, variables, context);
    }
  });
};
