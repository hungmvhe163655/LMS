import { useMutation } from '@tanstack/react-query';
import { AxiosError } from 'axios';
import { useNavigate, useSearchParams } from 'react-router-dom';

import { api } from '@/lib/api-client';
import { getActions } from '@/lib/auth-store';
import { MutationConfig } from '@/lib/react-query';
import { AuthResponse, Roles } from '@/types/api';
import { ERROR } from '@/types/constant';
import getRedirectBasedOnRoles from '@/utils/role-based-redirect';
import { setAccessToken, setRefreshToken } from '@/utils/storage-service';

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
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const redirectTo = searchParams.get('redirectTo');

  const { onSuccess, onError, ...restConfig } = mutationConfig || {};

  return useMutation({
    mutationFn: login,
    onSuccess: (data: AuthResponse, variables, context) => {
      const { token, user } = data;
      const roles = user.roles.map((role) => role.toUpperCase()) as Roles;

      // Lưu vào local
      setAccessToken(token.accessToken);
      setRefreshToken(token.refreshToken);

      // Để cho zustand quản lý
      const { setAccessData } = getActions();
      setAccessData({ id: user.id, roles: roles });

      if (redirectTo) {
        navigate(redirectTo, { replace: true });
      } else {
        navigate(getRedirectBasedOnRoles(roles));
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
