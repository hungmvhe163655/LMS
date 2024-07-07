import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

import ForgotPasswordRoute from './auth/forget-password';
import LoginRoute from './auth/login';
import RegisterRoute from './auth/register';
import ValidateEmailRoute from './auth/validate-email';
import StudentDashboardRoute from './dashboard/student';
import NewsRoute from './news';
import ProfileRoute from './profile';

export const createRouter = (queryClient: QueryClient) =>
  createBrowserRouter([
    {
      path: '/',
      lazy: async () => {
        queryClient; // Tạm
        const { LoginPage: LoginRoute } = await import('./auth/login/login-page');
        return { Component: LoginRoute };
      }
    },
    {
      path: '/news',
      children: [NewsRoute]
    },
    {
      path: '/dashboard',
      children: [StudentDashboardRoute]
    },
    {
      path: '/auth',
      children: [RegisterRoute, LoginRoute, ForgotPasswordRoute, ValidateEmailRoute]
    },
    {
      path: '/profile',
      children: [ProfileRoute]
    },
    {
      path: '*',
      lazy: async () => {
        const { NotFoundRoute } = await import('./not-found');
        return { Component: NotFoundRoute };
      }
    }
  ]);
