import { useMutation } from '@tanstack/react-query';
import { useNavigate } from 'react-router-dom';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';
import { AuthResponse } from '@/types/api';

import { RegisterInput } from '../utils/schema';

export const register = async (formData: RegisterInput): Promise<AuthResponse> => {
  const res = await api.post(`/auth/register/${formData.role.toLowerCase()}`, formData);
  if (res.status === 201) {
    const authResponse = res.data as AuthResponse;
    return authResponse;
  }
  throw new Error('Registration failed');
};

type UseRegisterOptions = {
  mutationConfig?: MutationConfig<typeof register>;
};

export const useRegister = ({ mutationConfig }: UseRegisterOptions = {}) => {
  const navigate = useNavigate();
  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: register,
    onSuccess: (...args) => {
      navigate('auth/not-verified');

      onSuccess?.(...args);
    },
    ...restConfig
  });
};
