import * as React from 'react';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  children: React.ReactNode;
};

export function Layout({ children }: LayoutProps) {
  return (
    <BaseLayout>
      <div className='mt-5 w-full p-10'>{children}</div>
    </BaseLayout>
  );
}
