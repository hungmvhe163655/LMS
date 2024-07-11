import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

interface ChangePasswordProps {
  userID: string;
  oldPassWord: string;
  newPassWord: string;
}

export const changePassword = async (props: ChangePasswordProps) => {
  return api.post('/profile/change-password', props);
};

type UseChangePasswordOptions = {
  mutationConfig?: MutationConfig<typeof changePassword>;
};

export const useChangePassword = ({ mutationConfig }: UseChangePasswordOptions = {}) => {
  const { ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: changePassword,
    ...restConfig
  });
};
