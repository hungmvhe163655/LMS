import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';
import { User } from '@/types/api';

export const getCurrentLoginUser = async (): Promise<User> => {
  const response = await api.get(`/auth/me`);
  return response.data;
};

export const getCurrentLoginUserOptions = () => {
  return queryOptions({
    queryKey: ['current-user'],
    queryFn: () => getCurrentLoginUser()
  });
};

type UseCurrentLoginUserOptions = {
  queryConfig?: QueryConfig<typeof getCurrentLoginUserOptions>;
};

export const useCurrentLoginUser = ({ queryConfig }: UseCurrentLoginUserOptions = {}) => {
  return useQuery({
    ...getCurrentLoginUserOptions(),
    ...queryConfig
  });
};
