import { queryOptions, useQuery } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { QueryConfig } from '@/lib/react-query';
import { Pagination } from '@/types/api';

import { NeedVerfiedAccount, VerifiedAccountsQueryParams } from '../types/api';
import { VerifiedAccountKeys } from '../utils/queries';

export const getVerifiedAccounts = async (
  params?: VerifiedAccountsQueryParams
): Promise<{ data: NeedVerfiedAccount[]; pagination: Pagination }> => {
  const response = await api.get(`/accounts/verification`, { params });
  const pagination = JSON.parse(response.headers['x-pagination']);
  return {
    data: response.data,
    pagination
  };
};

export const getVerifiedAccountsOptions = (params?: VerifiedAccountsQueryParams) => {
  return queryOptions({
    queryKey: VerifiedAccountKeys.list(params),
    queryFn: () => getVerifiedAccounts(params)
  });
};

type UseVerifiedAccountsOptions = {
  verifiedAccountsQueryParameter?: VerifiedAccountsQueryParams;
  queryConfig?: QueryConfig<typeof getVerifiedAccountsOptions>;
};

export const useGetVerifyAccounts = ({
  verifiedAccountsQueryParameter: verifiedAccountsQueryParameter,
  queryConfig
}: UseVerifiedAccountsOptions = {}) => {
  return useQuery({
    ...getVerifiedAccountsOptions(verifiedAccountsQueryParameter),
    ...queryConfig
  });
};
