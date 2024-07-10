import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

interface ChangeEmailProps {
  userID: string;
  email: string;
  verifyCode: string;
}

export const changeEmail = async (props: ChangeEmailProps) => {
  return api.post(`/accounts/change-email/${props.userID}`, props);
};

type UseChangeEmailOptions = {
  mutationConfig?: MutationConfig<typeof changeEmail>;
};

export const useChangeEmail = ({ mutationConfig }: UseChangeEmailOptions = {}) => {
  const { ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: changeEmail,
    ...restConfig
  });
};
