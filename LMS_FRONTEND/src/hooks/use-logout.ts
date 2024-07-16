import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';
import { clearTokens, getAccessToken, getRefreshToken } from '@/utils/storage-service';

export const logout = async () => {
  const token = {
    accessToken: getAccessToken(),
    refreshToken: getRefreshToken()
  };
  const res = await api.post('/auth/logout', token);
  return res;
};

type UseLogoutOptions = {
  mutationConfig?: MutationConfig<typeof logout>;
};

export const useLogout = ({ mutationConfig }: UseLogoutOptions = {}) => {
  const { onSuccess, ...restConfig } = mutationConfig || {};
  return useMutation({
    mutationFn: logout,
    onSuccess: (...args) => {
      clearTokens();
      onSuccess?.(...args);
    },
    ...restConfig
  });
};
