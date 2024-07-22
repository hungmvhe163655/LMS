import { QueryClient, QueryClientProvider } from '@tanstack/react-query';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';
import * as React from 'react';
import { ErrorBoundary } from 'react-error-boundary';
import { HelmetProvider } from 'react-helmet-async';

import { Spinner } from '@/components/app/spinner';
import { MainErrorFallback } from '@/components/errors/main';
import { Toaster } from '@/components/ui/toaster';
// import { queryClient } from '@/lib/react-query';

type AppProviderProps = {
  children: React.ReactNode;
};

const queryClient = new QueryClient();

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
            {children}
            <ReactQueryDevtools initialIsOpen={false} />
          </QueryClientProvider>
        </HelmetProvider>
        <Toaster />
      </ErrorBoundary>
    </React.Suspense>
  );
}
