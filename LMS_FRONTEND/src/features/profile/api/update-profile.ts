import { useMutation, useQueryClient } from '@tanstack/react-query';

import { getCurrentLoginUserOptions } from '@/hooks/use-current-login-user';
import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const updateProfile = async (data: any) => {
  const res = await api.put(`/profile`, data);
  return res.data;
};

type UseUpdateProfileOptions = {
  mutationConfig?: MutationConfig<typeof updateProfile>;
};

export const useUpdateProfile = ({ mutationConfig }: UseUpdateProfileOptions = {}) => {
  const queryClient = useQueryClient();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    ...restConfig,
    mutationFn: updateProfile,
    onSuccess: (...args) => {
      queryClient.invalidateQueries({
        queryKey: getCurrentLoginUserOptions().queryKey
      });
      onSuccess?.(...args);
    }
  });
};
