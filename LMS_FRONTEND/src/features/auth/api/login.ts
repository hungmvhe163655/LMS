import { useMutation } from '@tanstack/react-query';
import { AxiosError } from 'axios';
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { useNavigate, useSearchParams } from 'react-router-dom';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';
import { AuthResponse } from '@/types/api';
import getRedirectBasedOnRoles from '@/utils/role-based-redirect';
import { setAccessToken, setRefreshToken } from '@/utils/storage';

import { LoginInput } from '../utils/schema';

export const login = async (formData: LoginInput): Promise<AuthResponse> => {
  const res = await api.post('/auth/login', formData);
  if (res.status === 200) {
    const authResponse = res.data as AuthResponse;
    return authResponse;
  }
  throw new Error('Login failed');
};

type UseLoginOptions = {
  mutationConfig?: MutationConfig<typeof login>;
};

export const useLogin = ({ mutationConfig }: UseLoginOptions = {}) => {
  const signIn = useSignIn();
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const redirectTo = searchParams.get('redirectTo');

  const { onSuccess, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: login,
    onSuccess: (data: AuthResponse, variables, context) => {
      const { token, user } = data;
      setAccessToken(token.accessToken);
      setRefreshToken(token.refreshToken);

      const signInSuccess = signIn({
        auth: {
          token: token.accessToken,
          type: 'Bearer'
        },
        userState: {
          id: user.id,
          roles: user.roles.map((role) => role.toUpperCase())
        }
      });

      if (signInSuccess) {
        if (redirectTo) {
          navigate(redirectTo, { replace: true });
        } else {
          navigate(getRedirectBasedOnRoles(user.roles));
        }
      }

      onSuccess?.(data, variables, context);
    },
    onError: (error: AxiosError) => {
      const data = error.response?.data as { message: string };
      if (data?.message?.includes('UNVERIFIED')) {
        navigate('auth/not-verified');
      }
    },
    ...restConfig
  });
};
