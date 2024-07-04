import Axios, { InternalAxiosRequestConfig } from 'axios';

import { useToast } from '@/components/ui/use-toast';
import { env } from '@/config/env';
import { cookieStorage as storage } from '@/utils/cookie-storage';

function authRequestInterceptor(config: InternalAxiosRequestConfig) {
  if (config.headers) {
    config.headers.Accept = 'application/json';
    const token = storage.getToken();
    if (token) {
      config.headers.Authorization = token;
    }
  }

  config.withCredentials = true;
  return config;
}

export const api = Axios.create({
  baseURL: env.API_URL
});

api.interceptors.request.use(authRequestInterceptor);

api.interceptors.response.use(
  (response) => {
    return response;
  },

  (error) => {
    const message = error.response?.data?.message || error.message;
    const { toast } = useToast();
    toast({
      variant: 'destructive',
      description: message
    });

    if (error.response?.status === 401) {
      const searchParams = new URLSearchParams();
      const redirectTo = searchParams.get('redirectTo');
      window.location.href = `/auth/login?redirectTo=${redirectTo}`;
    }

    return Promise.reject(error);
  }
);
