import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { useActions } from '@/lib/auth-store';
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
  const { clearAccessData } = useActions();

  return useMutation({
    mutationFn: logout,
    onSuccess: (...args) => {
      try {
        clearAccessData();
      } catch (error) {
        console.log(error);
      }
      clearTokens();
      onSuccess?.(...args);
    },
    ...restConfig
  });
};
