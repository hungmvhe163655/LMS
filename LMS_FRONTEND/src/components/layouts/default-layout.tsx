import * as React from 'react';

import { ProtectedRoute } from '@/lib/protected-route';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  children: React.ReactNode;
};

export function Layout({ children }: LayoutProps) {
  return (
    <ProtectedRoute>
      <BaseLayout>
        <main className='mt-2 flex flex-1 flex-col p-10'>{children}</main>
      </BaseLayout>
    </ProtectedRoute>
  );
}
