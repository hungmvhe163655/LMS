import * as React from 'react';

import { Head } from '@/components/seo';

type DashboardLayoutProps = {
  children: React.ReactNode;
  title: string;
};

export function DashboardLayout({ children, title }: DashboardLayoutProps) {
  return (
    <>
      <Head title={title} />
      <div className='flex min-h-screen flex-col bg-gray-50'>
        <main className='grow'>
          <div className='w-full py-6 sm:px-6 lg:px-8'>
            <div className='px-4 py-6 sm:px-0'>{children}</div>
          </div>
        </main>
      </div>
    </>
  );
}
