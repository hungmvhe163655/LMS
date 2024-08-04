import { QueryClientProvider } from '@tanstack/react-query';
import * as React from 'react';
import AuthProvider from 'react-auth-kit/AuthProvider';
import createStore from 'react-auth-kit/createStore';
import { ErrorBoundary } from 'react-error-boundary';
import { HelmetProvider } from 'react-helmet-async';

import { Spinner } from '@/components/app/spinner';
import { MainErrorFallback } from '@/components/errors/main';
import { Toaster } from '@/components/ui/toaster';
import { queryClient } from '@/lib/react-query';
import { UserLogin } from '@/types/api';

type AppProviderProps = {
  children: React.ReactNode;
};

export function AppProvider({ children }: AppProviderProps) {
  const store = createStore<UserLogin>({
    authName: '_auth',
    authType: 'cookie',
    cookieDomain: window.location.hostname,
    cookieSecure: window.location.protocol === 'https:'
  });

  return (
    <React.Suspense
      fallback={
        <div className='flex h-screen w-screen items-center justify-center'>
          <Spinner size='xl' />
        </div>
      }
    >
      <ErrorBoundary fallback={<MainErrorFallback />}>
        <HelmetProvider>
          <QueryClientProvider client={queryClient}>
            <AuthProvider store={store}>{children}</AuthProvider>
          </QueryClientProvider>
        </HelmetProvider>
        <Toaster />
      </ErrorBoundary>
    </React.Suspense>
  );
}
