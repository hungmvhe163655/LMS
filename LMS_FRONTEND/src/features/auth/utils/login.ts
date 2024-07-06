import { useState } from 'react';
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { useNavigate, useSearchParams } from 'react-router-dom';

import { LoginInput } from './schema';

import { api } from '@/lib/api-client';
import { AuthResponse } from '@/types/api';
import { setAccessToken, setRefreshToken } from '@/utils/storage';

export const useLogin = () => {
  const signIn = useSignIn();
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const redirectTo = searchParams.get('redirectTo');
  const [isLoading, setLoading] = useState(false);

  const login = async (formData: LoginInput) => {
    setLoading(true);
    try {
      const res = await api.post('/auth/login', formData);

      if (res.status === 200) {
        const authResponse = res.data as AuthResponse;
        setAccessToken(authResponse.token.accessToken);
        setRefreshToken(authResponse.token.refreshToken);

        const signInSuccess = signIn({
          auth: {
            token: authResponse.token.accessToken,
            type: 'Bearer'
          },
          refresh: authResponse.token.refreshToken,
          userState: authResponse.user
        });

        if (signInSuccess) {
          const roles = authResponse.user.roles;

          if (redirectTo) {
            navigate(redirectTo ? redirectTo : '/', { replace: true });
          } else if (roles.includes('Supervisor')) {
            navigate('/dashboard/supervisor');
          } else if (roles.includes('Student')) {
            navigate('/dashboard/student');
          } else if (roles.includes('Lab Director')) {
            navigate('/dashboard/lab-director');
          }
        }
      }
    } catch (error) {
      setLoading(false);
    } finally {
      setLoading(false);
    }
  };

  return { login, isLoading };
};
