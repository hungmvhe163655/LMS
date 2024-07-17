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
        <div className='mt-2 h-dvh p-10'>{children}</div>
      </BaseLayout>
    </ProtectedRoute>
  );
}
