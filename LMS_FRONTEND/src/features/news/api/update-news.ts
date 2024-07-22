import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { getNewsQueryOptions } from './get-news';

export const updateNews = async (data: any) => {
  const res = await api.put(`/news`, data);
  return res.data;
};

type UseUpdateNewsOptions = {
  mutationConfig?: MutationConfig<typeof updateNews>;
};

export const useCreateNews = ({ mutationConfig }: UseUpdateNewsOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: updateNews,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({
        queryKey: getNewsQueryOptions().queryKey
      });
      onSuccess?.(...args);
    }
  });
};
