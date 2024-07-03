import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';
import { News, Pagination, PaginationParameters } from '@/types/api';

export const getNews = async (
  params?: PaginationParameters
): Promise<{ data: News[]; pagination: Pagination }> => {
  const response = await api.get(`/news`, { params });
  const pagination = JSON.parse(response.headers['x-pagination']);
  return {
    data: response.data,
    pagination
  };
};

export const getNewsQueryOptions = (params?: PaginationParameters) => {
  return queryOptions({
    queryKey: ['news', params],
    queryFn: () => getNews(params)
  });
};

type UseNewsOptions = {
  paginationParameter?: PaginationParameters;
  queryConfig?: QueryConfig<typeof getNewsQueryOptions>;
};

export const useNews = ({ paginationParameter, queryConfig }: UseNewsOptions = {}) => {
  return useQuery({
    ...getNewsQueryOptions(paginationParameter),
    ...queryConfig
  });
};
