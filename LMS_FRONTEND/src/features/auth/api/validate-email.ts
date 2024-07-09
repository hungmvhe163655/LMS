import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export type ValidateEmail = {
  email: string;
};

export const validateEmail = async (data: ValidateEmail): Promise<void> => {
  const res = await api.post('/auth/verify-email-send', data);
  if (res.status !== 200) {
    const message = res.data?.Message || 'Failed to validate email';
    throw new Error(message);
  }
};

type UseValidateEmailOptions = {
  mutationConfig?: MutationConfig<typeof validateEmail>;
};

export const useValidateEmail = ({ mutationConfig }: UseValidateEmailOptions = {}) => {
  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: validateEmail,
    onSuccess: (data, variables, context) => {
      onSuccess?.(data, variables, context);
    },
    ...restConfig
  });
};
