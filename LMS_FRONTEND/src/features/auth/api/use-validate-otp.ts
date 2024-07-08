import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router-dom';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export type ValidateOtp = {
  email: string;
  auCode: string;
};

export const validateOtp = async (data: ValidateOtp): Promise<void> => {
  const res = await api.put('/auth/verify-email', data);
  if (res.status !== 200) {
    const message = res.data?.Message || 'Failed to validate OTP';
    throw new Error(message);
  }
};

type UseValidateOtpOptions = {
  mutationConfig?: MutationConfig<typeof validateOtp>;
};

export const useValidateOtp = ({ mutationConfig }: UseValidateOtpOptions = {}) => {
  const navigate = useNavigate();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: validateOtp,
    onSuccess: (data, variables, context) => {
      navigate('/auth/register');
      onSuccess?.(data, variables, context);
    },
    ...restConfig
  });
};
