import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

import AuthRoute from './auth';
import ForgotPasswordRoute from './auth/forget-password';
import LoginRoute from './auth/login';
import RegisterRoute from './auth/register';
import ValidateEmailRoute from './auth/validate-email';
import LabDirectorDashboardRoute from './dashboard/lab-director';
import StudentDashboardRoute from './dashboard/student';
import SupervisorDashboardRoute from './dashboard/supervisor';
import ErrorRoute from './errors';
import ListNewsRoute from './news';
import NewsRoute from './news';
import ProfileRoute from './profile';
import EmailRoute from './profile/email';
import OverallRoute from './profile/overall';
import PasswordRoute from './profile/password';
import PhoneNumberRoute from './profile/phone-number';
import TwoFactorRoute from './profile/two-factor';
import ListAllTasksRoute from './project-workspace/list-all-task';
import ProjectWorkspaceRoute from './project-workspace/project-workspace';

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
      path: 'news',
      children: [NewsRoute]
    },
    {
      path: '/dashboard',
      children: [StudentDashboardRoute, SupervisorDashboardRoute, LabDirectorDashboardRoute]
    },
    {
      path: 'auth',
      children: [AuthRoute]
    },
    {
      path: 'profile',
      children: [ProfileRoute]
    },
    {
      path: 'error',
      children: [ErrorRoute]
    },
    {
      path: '/',
      children: [ListAllTasksRoute, ProjectWorkspaceRoute]
    },
    {
      path: '*',
      lazy: async () => {
        const { NotFoundRoute } = await import('./not-found');
        return { Component: NotFoundRoute };
      }
    }
  ]);
