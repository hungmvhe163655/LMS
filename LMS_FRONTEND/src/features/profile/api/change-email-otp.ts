import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

interface ChangeEmailOtpProps {
  userID: string;
  email: string;
  token: string;
}

export const changeEmailOtp = async (props: ChangeEmailOtpProps) => {
  return api.post(`/profile/change-email-otp/`, props);
};

type UseChangeEmailOtpOptions = {
  mutationConfig?: MutationConfig<typeof changeEmailOtp>;
};

export const useChangeEmailOtp = ({ mutationConfig }: UseChangeEmailOtpOptions = {}) => {
  const { ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: changeEmailOtp,
    ...restConfig
  });
};
