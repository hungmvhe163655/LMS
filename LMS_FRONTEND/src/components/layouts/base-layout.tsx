import * as React from 'react';

import { Footer } from '../shared/footer';
import { Header } from '../shared/header';

type LayoutProps = {
  children: React.ReactNode;
};

export function BaseLayout({ children }: LayoutProps) {
  return (
    <div className='flex h-dvh flex-col bg-gray-50'>
      <Header />
      {children}
      <Footer />
    </div>
  );
}
