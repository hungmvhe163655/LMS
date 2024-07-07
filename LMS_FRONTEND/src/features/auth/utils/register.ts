import { useState } from 'react';
import useSignIn from 'react-auth-kit/hooks/useSignIn';
import { useNavigate } from 'react-router-dom';

import { RegisterInput } from './schema';

import { api } from '@/lib/api-client';
import { AuthResponse } from '@/types/api';
import { setAccessToken, setRefreshToken } from '@/utils/storage';

export const useRegister = () => {
  const navigate = useNavigate();
  const signIn = useSignIn();
  const [isLoading, setLoading] = useState(false);

  const register = async (formData: RegisterInput) => {
    setLoading(true);
    try {
      const res = await api.post(`/auth/register/${formData.role.toLowerCase()}`, formData);

      if (res.status === 200) {
        const authResponse = res.data as AuthResponse;
        setAccessToken(authResponse.token.accessToken);
        setRefreshToken(authResponse.token.refreshToken);

        signIn({
          auth: {
            token: authResponse.token.accessToken,
            type: 'Bearer'
          },
          userState: authResponse.user
        });

        navigate('/auth/validate-email');
      }
    } catch (error) {
      setLoading(false);
    } finally {
      setLoading(false);
    }
  };

  return { register, isLoading };
};
