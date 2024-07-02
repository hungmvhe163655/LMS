import * as React from 'react';

import { Footer } from '../shared/footer';
import { Header } from '../shared/header';

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
