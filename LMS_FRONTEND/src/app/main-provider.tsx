import { QueryClientProvider } from '@tanstack/react-query';
import * as React from 'react';
import { ErrorBoundary } from 'react-error-boundary';
import { HelmetProvider } from 'react-helmet-async';

import { Spinner } from '@/components/app/spinner';
import { MainErrorFallback } from '@/components/errors/main';
import { Toaster } from '@/components/ui/sonner';
import { AuthLoader } from '@/lib/auth';
import { queryClient } from '@/lib/react-query';

type AppProviderProps = {
  children: React.ReactNode;
};

export function AppProvider({ children }: AppProviderProps) {
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
            <AuthLoader
              renderLoading={() => (
                <div className='flex h-screen w-screen items-center justify-center'>
                  <Spinner size='xl' />
                </div>
              )}
            >
              {children}
            </AuthLoader>
            <Toaster />
          </QueryClientProvider>
        </HelmetProvider>
      </ErrorBoundary>
    </React.Suspense>
  );
}
