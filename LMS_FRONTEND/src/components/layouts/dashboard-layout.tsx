import * as React from 'react';

import { Head } from '@/components/seo';
import { ProtectedRoute } from '@/lib/protected-route';

import { BaseLayout } from './base-layout';

type DashboardLayoutProps = {
  children: React.ReactNode;
  title: string;
};

export function DashboardLayout({ children, title }: DashboardLayoutProps) {
  return (
    <ProtectedRoute>
      <BaseLayout>
        <Head title={title} />
        <main className='h-dvh'>
          <div className='w-full py-6 sm:px-6 lg:px-8'>
            <div className='px-4 py-6 sm:px-0'>{children}</div>
          </div>
        </main>
      </BaseLayout>
    </ProtectedRoute>
  );
}
