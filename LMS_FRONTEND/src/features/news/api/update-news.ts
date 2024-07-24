import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { UpdateNewsInputSchema } from '../types/api';
import { newsKeys } from '../utils/queries';

export const updateNews = async ({
  data,
  newsId
}: {
  data: UpdateNewsInputSchema;
  newsId: string;
}) => {
  const res = await api.put(`/news/${newsId}`, data);
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
        queryKey: newsKeys.all
      });
      queryClient.invalidateQueries({
        queryKey: newsKeys.detail(variables.newsId)
      });
      onSuccess?.(data, variables, context);
    }
  });
};
