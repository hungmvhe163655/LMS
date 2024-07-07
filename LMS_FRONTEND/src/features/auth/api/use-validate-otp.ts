import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { api } from '@/lib/api-client';

export type ValidateOtp = {
  email: string;
  pin: string;
};

export const useValidateOtp = () => {
  const navigate = useNavigate();
  const [isLoading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const validateOtp = async (validateOtp: ValidateOtp) => {
    setLoading(true);
    try {
      const res = await api.post('/auth/verify-email', validateOtp);

      if (res?.status === 200) {
        navigate('/auth/register');
      }
    } catch (error: any) {
      setError(error.response?.data?.Message || error.message);
      setLoading(false);
    } finally {
      setLoading(false);
    }
  };

  return { validateOtp, isLoading, error };
};
