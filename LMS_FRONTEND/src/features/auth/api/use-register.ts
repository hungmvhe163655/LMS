import { useMutation } from '@tanstack/react-query';
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { useNavigate } from 'react-router-dom';

import { RegisterInput } from '../utils/schema';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';
import { AuthResponse } from '@/types/api';
import { setAccessToken, setRefreshToken } from '@/utils/storage';

export const register = async (formData: RegisterInput): Promise<AuthResponse> => {
  const res = await api.post(`/auth/register/${formData.role.toLowerCase()}`, formData);
  if (res.status === 200) {
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
  const signIn = useSignIn();

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: register,
    onSuccess: (data: AuthResponse, variables, context) => {
      const { token, user } = data;
      setAccessToken(token.accessToken);
      setRefreshToken(token.refreshToken);

      signIn({
        auth: {
          token: token.accessToken,
          type: 'Bearer'
        },
        userState: user
      });

      navigate('/auth/validate-email');
      onSuccess?.(data, variables, context);
    },
    ...restConfig
  });
};
