import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { CreateNewsAPISchema } from '../types/api';
import { newsKeys } from '../utils/queries';

export const createNews = async (data: CreateNewsAPISchema) => {
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
        queryKey: newsKeys.all
      });
      onSuccess?.(...args);
    }
  });
};
