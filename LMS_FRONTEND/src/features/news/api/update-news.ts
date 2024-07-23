import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { getNewsIdQueryOptions } from './get-news-id';

export const updateNews = async (data: any) => {
  const res = await api.put(`/news/${data.id}`, data);
  return res.data;
};

type UseUpdateNewsOptions = {
  mutationConfig?: MutationConfig<typeof updateNews>;
};

export const useUpdateNews = ({ mutationConfig }: UseUpdateNewsOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: updateNews,
    onSuccess: (data, variables, context) => {
      queryClient.invalidateQueries({
        queryKey: ['news']
      });
      queryClient.invalidateQueries({
        queryKey: getNewsIdQueryOptions(variables.id).queryKey
      });
      onSuccess?.(data, variables, context);
    }
  });
};
