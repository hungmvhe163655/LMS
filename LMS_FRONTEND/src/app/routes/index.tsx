import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

import AuthRoute from './auth';
import LabDirectorDashboardRoute from './dashboard/lab-director';
import StudentDashboardRoute from './dashboard/student';
import SupervisorDashboardRoute from './dashboard/supervisor';
import BookingScheduleRoute from './device/booking-schedule';
import DevicesListRoute from './device/devices-list';
import ErrorRoute from './errors';
import NewsRoute from './news';
import ProfileRoute from './profile';
import ListAllTasksRoute from './project/list-all-task';
import ListProjectTasksRoute from './project/list-project-tasks';
import MembersRoute from './project/members';
import OngoingProjectsRoute from './project/ongoings';
import ResourcesRoute from './project/resources';
import SettingsRoute from './project/settings';
import WorkspaceRoute from './project/workspace';
import SupervisorRoute from './supervisor';
import VerifyAccountsRoute from './verify-account';

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
      path: 'dashboard',
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
      path: 'verify-account',
      children: [VerifyAccountsRoute]
    },
    {
      path: 'error',
      children: [ErrorRoute]
    },
    {
      path: 'project',
      children: [
        OngoingProjectsRoute,
        WorkspaceRoute,
        ListAllTasksRoute,
        ListProjectTasksRoute,
        SettingsRoute,
        MembersRoute,
        ResourcesRoute
      ]
    },
    {
      path: 'device',
      children: [BookingScheduleRoute, DevicesListRoute]
    },
    {
      path: '/',
      children: [ListAllTasksRoute]
    },
    {
      path: '*',
      lazy: async () => {
        const { NotFoundPage: NotFoundPage } = await import('./not-found-page');
        return { Component: NotFoundPage };
      }
    }
  ]);
