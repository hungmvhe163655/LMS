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
      <div className='min-h-screen flex flex-col bg-gray-50'>
        <header className='bg-white shadow'>
          <div className='w-full py-6 px-4 sm:px-6 lg:px-8'>
            <h1 className='text-3xl font-bold text-gray-900'>{title}</h1>
          </div>
        </header>
        <main className='flex-grow'>
          <div className='w-full py-6 sm:px-6 lg:px-8'>
            <div className='px-4 py-6 sm:px-0'>{children}</div>
          </div>
        </main>
      </div>
    </>
  );
}
