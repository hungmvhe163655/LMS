import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

import AuthRoute from './auth';
import LabDirectorDashboardRoute from './dashboard/lab-director';
import StudentDashboardRoute from './dashboard/student';
import SupervisorDashboardRoute from './dashboard/supervisor';
import BookingScheduleRoute from './device/booking-schedule';
import ErrorRoute from './errors';
import NewsRoute from './news';
import ProfileRoute from './profile';
import ProjectResourcesRoute from './project-resources';
import ListAllTasksRoute from './project-workspace/list-all-task';
import ListProjectTasksRoute from './project-workspace/list-project-tasks';
import OngoingProjectsRoute from './project-workspace/ongoing-projects';
import ProjectMembersRoute from './project-workspace/project-members';
import ProjectSettingsRoute from './project-workspace/project-settings';
import ProjectWorkspaceRoute from './project-workspace/project-workspace';
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
        ProjectWorkspaceRoute,
        ListAllTasksRoute,
        ListProjectTasksRoute,
        ProjectSettingsRoute,
        ProjectMembersRoute
      ]
    },
    {
      path: 'device',
      children: [BookingScheduleRoute]
    },
    {
      path: 'resources',
      children: [ProjectResourcesRoute]
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
