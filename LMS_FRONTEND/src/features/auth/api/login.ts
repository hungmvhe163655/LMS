import { useMutation } from '@tanstack/react-query';
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { useNavigate, useSearchParams } from 'react-router-dom';

import useRoleBasedRedirect from '@/hooks/use-role-based-redirect';
import { api } from '@/lib/api-client';
import { MutationConfig } from '@/lib/react-query';
import { AuthResponse } from '@/types/api';
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
  const { getRedirectBasedOnRoles, setUser } = useRoleBasedRedirect(null);

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
        userState: user
      });

      if (signInSuccess) {
        if (redirectTo) {
          navigate(redirectTo, { replace: true });
        } else {
          setUser(user);
          navigate(getRedirectBasedOnRoles());
        }
      }

      onSuccess?.(data, variables, context);
    },
    ...restConfig
  });
};
