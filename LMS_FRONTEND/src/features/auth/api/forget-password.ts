import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const forgetPassword = async (email: string) => {
  return api.post('/auth/forgot-password', { email });
};

type UseForgetPasswordOptions = {
  mutationConfig?: MutationConfig<typeof forgetPassword>;
};

export const useForgetPassword = ({ mutationConfig }: UseForgetPasswordOptions = {}) => {
  const { ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: forgetPassword,
    ...restConfig
  });
};
