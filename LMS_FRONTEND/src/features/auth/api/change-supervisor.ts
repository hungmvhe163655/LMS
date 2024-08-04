import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const changeSupervisor = ({ verifierId, id }: { verifierId: string; id: string }) => {
  return api.put('/auth/verifier-change', { verifierId, id });
};

type UseChangeSupervisorOptions = {
  mutationConfig?: MutationConfig<typeof changeSupervisor>;
};

export const useChangeSupervisor = ({ mutationConfig }: UseChangeSupervisorOptions = {}) => {
  const { ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: changeSupervisor,
    ...restConfig
  });
};
