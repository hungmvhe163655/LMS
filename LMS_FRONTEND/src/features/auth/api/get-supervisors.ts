import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';

import { Supervisor } from '../utils/schema';

export const getSupervisors = async (): Promise<Supervisor[]> => {
  const response = await api.get(`/auth/accounts-supervisor`);
  return response.data;
};

export const getSupervisorsOptions = () => {
  return queryOptions({
    queryKey: ['supervisors'],
    queryFn: () => getSupervisors()
  });
};

type UseSupervisorsOptions = {
  queryConfig?: QueryConfig<typeof getSupervisorsOptions>;
};

export const useSupervisors = ({ queryConfig }: UseSupervisorsOptions = {}) => {
  return useQuery({
    ...getSupervisorsOptions(),
    ...queryConfig
  });
};
