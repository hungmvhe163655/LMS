import axios, { InternalAxiosRequestConfig } from 'axios';

import { toast } from '@/components/ui/use-toast';
import { env } from '@/config/env';
import { ERROR } from '@/types/constant';
import {
  clearTokens,
  getAccessToken,
  getRefreshToken,
  setAccessToken,
  setRefreshToken
} from '@/utils/storage-service';

import { authStore } from './auth-store';

function authRequestInterceptor(config: InternalAxiosRequestConfig) {
  if (config.headers) {
    config.headers.Accept = 'application/json';
    const token = getAccessToken();
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    config.headers['Cache-Control'] = 'no-cache';
    config.headers['Pragma'] = 'no-cache';
    config.headers['Expires'] = '0';
  }

  config.withCredentials = true;
  return config;
}

export const api = axios.create({
  baseURL: env.API_URL
});

api.interceptors.request.use(authRequestInterceptor, (error) => Promise.reject(error));

api.interceptors.response.use(
  (response) => {
    return response;
  },

  async (error) => {
    const message: string =
      error.response?.data?.Message || error.response?.data?.message || error.message;

    const originalRequest = error.config;

    // Bị Banned
    if (message.includes(ERROR.IS_BANNED)) {
      toast({
        variant: 'destructive',
        description: 'Your account is Banned!'
      });
      return Promise.reject(error);
    }

    // Chưa Verified
    if (message.includes(ERROR.UNVERIFIED)) {
      toast({
        variant: 'destructive',
        description: 'Your account not Verified yet!'
      });
      return Promise.reject(error);
    }

    // Không có quyền truy cập
    if (error.response?.status === 403) {
      toast({
        variant: 'destructive',
        description: "You're not allowed!"
      });
      window.location.href = `/error/not-authorized`;
      return Promise.reject(error);
    }

    // Chưa đăng nhập
    if (error.response?.status === 401 && !originalRequest._retry) {
      originalRequest._retry = true;
      const token = {
        accessToken: getAccessToken(),
        refreshToken: getRefreshToken()
      };

      const response = await axios.post(`${env.API_URL}/token/refresh-token`, token);
      const { accessToken, refreshToken } = response.data;

      // Nếu token được làm mới lại thì gửi lại Request
      if (refreshToken) {
        setAccessToken(accessToken);
        setRefreshToken(refreshToken);

        originalRequest.headers.Authorization = `Bearer ${accessToken}`;
        return api(originalRequest);
      }
      const { clearAccessData } = authStore.getState();
      clearAccessData();
      clearTokens();
      window.location.href = '/auth/login';
      return Promise.reject(error);
    }

    toast({
      variant: 'destructive',
      description: message
    });

    return Promise.reject(error);
  }
);
