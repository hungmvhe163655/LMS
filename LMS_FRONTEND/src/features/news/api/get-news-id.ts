import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import { News } from '../types/api';
import { newsKeys } from '../utils/queries';

export const getNewsId = async (id: string): Promise<News> => {
  const response = await api.get(`/news/${id}`);
  return response.data;
};

export const getNewsIdQueryOptions = (id: string) => {
  return queryOptions({
    queryKey: newsKeys.detail(id),
    queryFn: () => getNewsId(id)
  });
};

type UseNewsByIdOptions = {
  id: string;
  queryConfig?: QueryConfig<typeof getNewsIdQueryOptions>;
};

export const useNewsById = ({ id, queryConfig }: UseNewsByIdOptions) => {
  return useQuery({
    ...getNewsIdQueryOptions(id),
    ...queryConfig
  });
};
