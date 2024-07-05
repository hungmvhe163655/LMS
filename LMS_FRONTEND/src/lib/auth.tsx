import { AxiosResponse } from 'axios';
import { configureAuth } from 'react-query-auth';
import { useLocation, Navigate } from 'react-router-dom';
import { z } from 'zod';

import { api } from './api-client';

import { AuthResponse, User } from '@/types/api';
import {
  clearTokens,
  getAccessToken,
  getRefreshToken,
  setAccessToken,
  setRefreshToken
} from '@/utils/storage';

// api call definitions for auth (types, schemas, requests):
// these are not part of features as this is a module shared across features

export async function handleApiResponse(response: AxiosResponse) {
  return await response.data;
}

const getUser = (): Promise<User | undefined> => {
  return api.get('/auth/me').then(handleApiResponse) ?? null;
};

const logout = async (): Promise<void> => {
  const tokens = {
    accessToken: getAccessToken(),
    refreshToken: getRefreshToken()
  };
  const response = await api.post('/auth/logout', tokens);
  clearTokens();
  return handleApiResponse(response);
};

export const loginInputSchema = z.object({
  email: z.string().min(1, 'Required').email('Invalid email'),
  password: z.string().min(5, 'Required')
});

export type LoginInput = z.infer<typeof loginInputSchema>;

const loginWithEmailAndPassword = async (data: LoginInput): Promise<AuthResponse> => {
  const response = await api.post('/auth/login', data);
  return handleApiResponse(response);
};

export const registerInputSchema = z
  .object({
    email: z.string().min(1, 'Required'),
    role: z.enum(['STUDENT', 'SUPERVISOR']),
    fullname: z.string().min(1, 'Required'),
    password: z.string().min(1, 'Required'),
    confirmPassword: z.string().min(1, 'Required'),
    gender: z.boolean({
      required_error: 'Required'
    }),
    phonenumber: z
      .string()
      .min(1, 'Required')
      .regex(/^\d{10}$/, {
        message: 'Phone number must be exactly 10 digits'
      })
  })
  .superRefine(({ confirmPassword, password }, ctx) => {
    if (confirmPassword !== password) {
      ctx.addIssue({
        code: 'custom',
        message: 'The passwords did not match',
        path: ['confirmPassword']
      });
    }
  });

export type RegisterInput = z.infer<typeof registerInputSchema>;

const registerWithEmailAndPassword = async (data: RegisterInput): Promise<AuthResponse> => {
  const endpoint = data.role === 'STUDENT' ? '/auth/register/student' : '/auth/register/supervisor';
  return api.post(endpoint, data).then(handleApiResponse);
};
const authConfig = {
  userFn: getUser,
  loginFn: async (data: LoginInput) => {
    const response = await loginWithEmailAndPassword(data);
    setAccessToken(response.token.accessToken);
    setRefreshToken(response.token.refreshToken);
    return response.user;
  },
  registerFn: async (data: RegisterInput) => {
    const response = await registerWithEmailAndPassword(data);
    setAccessToken(response.token.accessToken);
    setRefreshToken(response.token.refreshToken);
    return response.user;
  },
  logoutFn: logout
};

export const { useUser, useLogin, useLogout, useRegister, AuthLoader } = configureAuth(authConfig);

export const ProtectedRoute = ({ children }: { children: React.ReactNode }) => {
  const user = useUser();
  const location = useLocation();

  if (!user.data) {
    return (
      <Navigate to={`/auth/login?redirectTo=${encodeURIComponent(location.pathname)}`} replace />
    );
  }

  return children;
};
