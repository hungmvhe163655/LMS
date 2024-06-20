import * as React from 'react';

import { Footer } from '../app/footer';
import { Header } from '../app/header';

type LayoutProps = {
  children: React.ReactNode;
};

export function BaseLayout({ children }: LayoutProps) {
  return (
    <>
      <Header />
      {children}
      <Footer />
    </>
  );
}
