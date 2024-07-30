import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';
import { Pagination } from '@/types/api';

import { News, NewsQueryParams } from '../types/api';
import { newsKeys } from '../utils/queries';

export const getNews = async (
  params?: NewsQueryParams
): Promise<{ data: News[]; pagination: Pagination }> => {
  const response = await api.get(`/news`, { params });
  const pagination = JSON.parse(response.headers['x-pagination']);
  return {
    data: response.data,
    pagination
  };
};

export const getNewsQueryOptions = (params?: NewsQueryParams) => {
  return queryOptions({
    queryKey: newsKeys.list(params),
    queryFn: () => getNews(params)
  });
};

type UseNewsOptions = {
  newsQueryParameter?: NewsQueryParams;
  queryConfig?: QueryConfig<typeof getNewsQueryOptions>;
};

export const useNews = ({ newsQueryParameter, queryConfig }: UseNewsOptions = {}) => {
  return useQuery({
    ...getNewsQueryOptions(newsQueryParameter),
    ...queryConfig
  });
};
