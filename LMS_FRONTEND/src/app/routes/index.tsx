import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

import ForgotPasswordRoute from './auth/forget-password';
import LoginRoute from './auth/login';
import RegisterRoute from './auth/register';
import ValidateEmailRoute from './auth/validate-email';
import StudentDashboardRoute from './dashboard/student';
import ListNewsRoute from './news';
import EmailRoute from './profile/email';
import OverallRoute from './profile/overall';
import PasswordRoute from './profile/password';
import PhoneNumberRoute from './profile/phone-number';
import TwoFactorRoute from './profile/two-factor';
import ListAllTasksRoute from './project-workspace/list-all-task';

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
      children: [ListNewsRoute]
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
      children: [OverallRoute, EmailRoute, PasswordRoute, PhoneNumberRoute, TwoFactorRoute]
    },
    {
      path: '/',
      children: [ListAllTasksRoute]
    }
  ]);
