import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { resourceKeys } from '../utils/queries';

export const deleteFile = async ({ id }: { id: string }) => {
  const res = await api.delete(`/files/${id}`);
  return res.data;
};

type UseDeleteFileOptions = {
  mutationConfig?: MutationConfig<typeof deleteFile>;
};

export const useDeleteFile = ({ mutationConfig }: UseDeleteFileOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: deleteFile,
    onSuccess: (data, variables, context) => {
      queryClient.invalidateQueries({
        queryKey: resourceKeys.content(variables.id)
      });
      onSuccess?.(data, variables, context);
    }
  });
};
