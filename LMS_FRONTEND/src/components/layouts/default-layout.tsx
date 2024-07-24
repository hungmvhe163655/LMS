import * as React from 'react';

import { ProtectedRoute } from '@/lib/protected-route';
import { Roles } from '@/types/api';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  children: React.ReactNode;
  roles?: Roles;
};

export function Layout({ children, roles }: LayoutProps) {
  return (
    <ProtectedRoute roles={roles}>
      <BaseLayout>
        <main className='mt-2 flex flex-1 flex-col p-10'>{children}</main>
      </BaseLayout>
    </ProtectedRoute>
  );
}
