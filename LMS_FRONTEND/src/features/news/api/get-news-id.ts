import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import { News } from '../types/api';

export const getNewsId = async (id: string): Promise<News> => {
  const response = await api.get(`/news/${id}`);
  return response.data;
};

export const getNewsQueryOptions = (id: string) => {
  return queryOptions({
    queryKey: ['newsById', id],
    queryFn: () => getNewsId(id)
  });
};

type UseNewsByIdOptions = {
  id: string;
  queryConfig?: QueryConfig<typeof getNewsQueryOptions>;
};

export const useNewsById = ({ id, queryConfig }: UseNewsByIdOptions) => {
  return useQuery({
    ...getNewsQueryOptions(id),
    ...queryConfig
  });
};
