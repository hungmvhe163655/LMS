import * as React from 'react';

import { Head } from '@/components/seo';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  children: React.ReactNode;
  title: string;
};

export function Layout({ children, title }: LayoutProps) {
  return (
    <BaseLayout>
      <Head title={title} />
      <div className='flex grow flex-col justify-center bg-gray-50 py-6 sm:px-6 lg:px-8'>
        <div className='sm:mx-auto sm:w-full sm:max-w-md'>
          <div className='flex justify-center' />

          <h2 className='mt-1 text-center text-3xl font-extrabold text-gray-900'>{title}</h2>
        </div>

        <div className='my-5 w-full sm:mx-auto sm:max-w-md'>{children}</div>
      </div>
    </BaseLayout>
  );
}
