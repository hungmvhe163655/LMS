import { useMutation } from '@tanstack/react-query';
import useSignOut from 'react-auth-kit/hooks/useSignOut';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';
import { clearTokens, getAccessToken, getRefreshToken } from '@/utils/storage';

export const logout = () => {
  const token = {
    accessToken: getAccessToken(),
    refreshToken: getRefreshToken()
  };

  return api.post('/auth/logout', token);
};

type UseLogoutOptions = {
  mutationConfig?: MutationConfig<typeof logout>;
};

export const useLogout = ({ mutationConfig }: UseLogoutOptions = {}) => {
  const signOut = useSignOut();
  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: logout,
    onSuccess: (data, variables, context) => {
      clearTokens();
      signOut();
      onSuccess?.(data, variables, context);
    },
    ...restConfig
  });
};
