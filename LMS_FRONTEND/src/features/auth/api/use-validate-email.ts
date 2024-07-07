import { useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { api } from '@/lib/api-client';

export type ValidateEmail = {
  email: string;
};

export const useValidateEmail = () => {
  const navigate = useNavigate();
  const [isLoading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const validateEmail = async (validateEmail: ValidateEmail) => {
    setLoading(true);
    try {
      const res = await api.post('/auth/verify-email-send', validateEmail);

      if (res?.status === 200) {
        navigate('/auth/validate-email/otp');
      }
    } catch (error: any) {
      setError(error.response?.data?.Message || error.message);
    } finally {
      setLoading(false);
    }
  };

  return { validateEmail, isLoading, error };
};
