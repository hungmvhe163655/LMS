import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { getNewsQueryOptions } from './get-news';

export const createNews = async (data: any) => {
  const res = await api.post(`/news`, data);
  return res.data;
};

type UseCreateNewsOptions = {
  mutationConfig?: MutationConfig<typeof createNews>;
};

export const useCreateNews = ({ mutationConfig }: UseCreateNewsOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: createNews,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({
        queryKey: getNewsQueryOptions().queryKey
      });
      onSuccess?.(...args);
    }
  });
};
