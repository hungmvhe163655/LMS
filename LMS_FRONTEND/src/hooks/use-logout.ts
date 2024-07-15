import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { getActions } from '@/lib/auth-store';
import { MutationConfig } from '@/lib/react-query';
import { StorageService } from '@/utils/storage-service';

export const logout = () => {
  const token = {
    accessToken: StorageService.getAccessToken(),
    refreshToken: StorageService.getRefreshToken()
  };

  return api.post('/auth/logout', token);
};

type UseLogoutOptions = {
  mutationConfig?: MutationConfig<typeof logout>;
};

export const useLogout = ({ mutationConfig }: UseLogoutOptions = {}) => {
  const { onSuccess, ...restConfig } = mutationConfig || {};
  const { clearTokens } = getActions();

  return useMutation({
    mutationFn: logout,
    onSuccess: (data, variables, context) => {
      clearTokens();
      onSuccess?.(data, variables, context);
    },
    ...restConfig
  });
};
