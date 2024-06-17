import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

import EmailRoute from './profile/email';
import OverallRoute from './profile/overall';
import PasswordRoute from './profile/password';
import PhoneNumberRoute from './profile/phone-number';
import TwoFactorRoute from './profile/two-factor';

export const createRouter = (queryClient: QueryClient) =>
  createBrowserRouter([
    {
      path: '/',
      lazy: async () => {
        queryClient; // Tạm
        const { LoginRoute } = await import('./auth/login');
        return { Component: LoginRoute };
      }
    },
    {
      path: '/register/choose-role',
      lazy: async () => {
        queryClient;
        const { ChooseRoleRoute } = await import('./register/choose-role');
        return { Component: ChooseRoleRoute };
      }
    },
    {
      path: '/auth/forgot-password',
      lazy: async () => {
        queryClient;
        const { ForgotPasswordRoute } = await import('./auth/forgot-password');
        return { Component: ForgotPasswordRoute };
      }
    },
    {
      path: '/auth/validate-email',
      lazy: async () => {
        queryClient;
        const { ValidateEmailRoute } = await import('./auth/validate-email');
        return { Component: ValidateEmailRoute };
      }
    },
    {
      path: '/auth/validate-roll-number',
      lazy: async () => {
        queryClient;
        const { ValidateRollNumberRoute } = await import('./auth/validate-student-roll-number');
        return { Component: ValidateRollNumberRoute };
      }
    },
    {
      path: '/register/student',
      lazy: async () => {
        queryClient;
        const { StudentRegisterRoute } = await import('./register/student-register');
        return { Component: StudentRegisterRoute };
      }
    },
    {
      path: '/register/supervisor',
      lazy: async () => {
        queryClient;
        const { SupervisorRegisterRoute } = await import('./register/supervisor-register');
        return { Component: SupervisorRegisterRoute };
      }
    },
    {
      path: '/news/list',
      lazy: async () => {
        queryClient;
        const { ListNewsRoute } = await import('./news/list-news');
        return { Component: ListNewsRoute };
      }
    },
    {
      path: '/news/create',
      lazy: async () => {
        queryClient;
        const { CreateNewsRoute } = await import('./news/create-news');
        return { Component: CreateNewsRoute };
      }
    },
    {
      path: '/student/dashboard',
      lazy: async () => {
        const { StudentDashboardRoute } = await import('./student/student-dashboard');
        return { Component: StudentDashboardRoute };
      }
    },
    {
      path: 'profile',
      children: [OverallRoute, EmailRoute, PasswordRoute, PhoneNumberRoute, TwoFactorRoute]
    }
  ]);
