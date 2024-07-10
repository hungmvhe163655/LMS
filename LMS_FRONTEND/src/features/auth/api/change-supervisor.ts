import { useMutation } from '@tanstack/react-query';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';

export const changeSupervisor = async (supervisorId: string) => {
  return api.post('/auth/change-supervisor', { supervisorId });
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
