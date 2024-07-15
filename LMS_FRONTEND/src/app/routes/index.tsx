import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

import AuthRoute from './auth';
import LabDirectorDashboardRoute from './dashboard/lab-director';
import StudentDashboardRoute from './dashboard/student';
import SupervisorDashboardRoute from './dashboard/supervisor';
import ErrorRoute from './errors';
import NewsRoute from './news';
import ProfileRoute from './profile';
import ListAllTasksRoute from './project-workspace/list-all-task';
import ProjectWorkspaceRoute from './project-workspace/project-workspace';
import SupervisorRoute from './supervisor';

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
      path: 'supervisor',
      children: [SupervisorRoute]
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
        const { NotFoundPage: NotFoundPage } = await import('./not-found-page');
        return { Component: NotFoundPage };
      }
    }
  ]);
