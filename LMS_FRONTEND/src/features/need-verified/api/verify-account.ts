import { useMutation, useQueryClient } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

import { VerifyAccount } from '../types/api';
import { VerifiedAccountKeys } from '../utils/queries';

export const verifyAccounts = async (data: VerifyAccount[]) => {
  const res = await api.post(`/accounts/verification`, { users: data });
  return res.data;
};

type UseVerifyAccountsOptions = {
  mutationConfig?: MutationConfig<typeof verifyAccounts>;
};

export const useVerifyAccounts = ({ mutationConfig }: UseVerifyAccountsOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: verifyAccounts,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({
        queryKey: VerifiedAccountKeys.lists()
      });
      onSuccess?.(...args);
    }
  });
};
