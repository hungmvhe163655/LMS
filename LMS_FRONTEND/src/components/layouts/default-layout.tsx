import * as React from 'react';

import { BaseLayout } from './base-layout';

import { ProtectedRoute } from '@/lib/auth';

type LayoutProps = {
  children: React.ReactNode;
};

export function Layout({ children }: LayoutProps) {
  return (
    <ProtectedRoute>
      <BaseLayout>
        <div className='mt-5 w-full p-10'>{children}</div>
      </BaseLayout>
    </ProtectedRoute>
  );
}
