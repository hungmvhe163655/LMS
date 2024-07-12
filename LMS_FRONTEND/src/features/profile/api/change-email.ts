import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

interface ChangeEmailProps {
  userID: string;
  email: string;
}

export const changeEmail = async (props: ChangeEmailProps) => {
  return api.post(`/profile/change-email/`, props);
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