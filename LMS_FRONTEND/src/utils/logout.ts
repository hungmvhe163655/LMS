import { useState } from 'react';
import useSignOut from 'react-auth-kit/hooks/useSignOut';
import { useNavigate } from 'react-router-dom';

import { api } from '@/lib/api-client';
import { clearTokens, getAccessToken, getRefreshToken } from '@/utils/storage';

export const useLogout = () => {
  const signOut = useSignOut();
  const navigate = useNavigate();
  const [isLoading, setLoading] = useState(false);

  const logout = async () => {
    setLoading(true);
    const token = {
      accessToken: getAccessToken(),
      refreshToken: getRefreshToken()
    };
    try {
      const res = await api.post('/auth/logout', token);

      if (res.status === 200) {
        signOut();
        clearTokens();
        navigate('/');
      }
    } catch (error) {
      setLoading(false);
    } finally {
      setLoading(false);
    }
  };

  return { logout, isLoading };
};
