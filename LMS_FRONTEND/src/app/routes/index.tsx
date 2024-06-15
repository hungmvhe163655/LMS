import { QueryClient } from '@tanstack/react-query';
import { createBrowserRouter } from 'react-router-dom';

export const createRouter = (queryClient: QueryClient) =>
  createBrowserRouter([
    {
      path: '/',
      lazy: async () => {
        queryClient; // Tạm
        const { LoginRoute } = await import('./auth/login');
        return { Component: LoginRoute };
      }
    }
  ]);
