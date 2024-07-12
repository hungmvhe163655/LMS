import { useMutation } from '@tanstack/react-query';
import { AxiosError } from 'axios';
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { useNavigate, useSearchParams } from 'react-router-dom';

import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';
import { AuthResponse, Roles } from '@/types/api';
import { ERROR } from '@/types/constant';
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

  const { onSuccess, onError, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: login,
    onSuccess: (data: AuthResponse, variables, context) => {
      const { token, user } = data;
      setAccessToken(token.accessToken);
      setRefreshToken(token.refreshToken);
      const roles = user.roles.map((role) => role.toUpperCase()) as Roles;

      const signInSuccess = signIn({
        auth: {
          token: token.accessToken,
          type: 'Bearer'
        },
        userState: {
          id: user.id,
          roles
        }
      });

      if (signInSuccess) {
        if (redirectTo) {
          navigate(redirectTo, { replace: true });
        } else {
          navigate(getRedirectBasedOnRoles(roles));
        }
      }

      onSuccess?.(data, variables, context);
    },
    onError: (error: AxiosError, ...rest) => {
      const data: any = error.response?.data;
      if (data?.message?.includes(ERROR.UNVERIFIED)) {
        navigate('/auth/not-verified', { state: { errorData: data } });
      }

      onError?.(error, ...rest);
    },
    ...restConfig
  });
};