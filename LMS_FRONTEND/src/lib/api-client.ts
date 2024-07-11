import Axios, { InternalAxiosRequestConfig } from 'axios';

import { toast } from '@/components/ui/use-toast';
import { env } from '@/config/env';
import { ERROR } from '@/types/constant';
import { getAccessToken } from '@/utils/storage';

import { refreshToken } from './refresh-token';

function authRequestInterceptor(config: InternalAxiosRequestConfig) {
  if (config.headers) {
    config.headers.Accept = 'application/json';
    const token = getAccessToken();
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
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

  async (error) => {
    const message: string =
      error.response?.data?.Message || error.response?.data?.message || error.message;

    if (message.includes(ERROR.IS_BANNED)) {
      window.location.href = `/error/ban-account`;
      return Promise.reject(error);
    }

    if (message.includes(ERROR.UNVERIFIED)) {
      window.location.href = `/auth/not-verified`;
      return Promise.reject(error);
    }

    toast({
      variant: 'destructive',
      description: message
    });

    // Chưa đăng nhập
    if (error.response?.status === 401) {
      const originalRequest = error.config;
      const newAccessToken = await refreshToken();

      // Nếu token được làm mới lại thì gửi lại Request
      if (newAccessToken) {
        originalRequest.headers.Authorization = `Bearer ${newAccessToken}`;
        return api(originalRequest);
      }

      const searchParams = new URLSearchParams();
      const redirectTo = searchParams.get('redirectTo');
      if (redirectTo) {
        window.location.href = `/auth/login?redirectTo=${redirectTo}`;
      }
    }

    // Không có quyền truy cập
    if (error.response?.status === 403) {
      window.location.href = `/error/forbidden`;
    }

    return Promise.reject(error);
  }
);
