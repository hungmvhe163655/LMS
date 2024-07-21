import { Head } from '../seo/head';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  children: React.ReactNode;
};

export function Layout({ children }: LayoutProps) {
  return (
    <BaseLayout>
      <Head title={'error'} />
      {children}
    </BaseLayout>
  );
}
