import { SidebarNav } from '@/features/profile/components/sidebar';
import { SidebarNavItem } from '@/features/profile/types/type';
import { ProtectedRoute } from '@/lib/protected-route';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  children: React.ReactNode;
};

const sidebarItems: SidebarNavItem[] = [
  {
    title: 'Overall',
    href: '/profile'
  },
  {
    title: 'Change Password',
    href: '/profile/password'
  },
  {
    title: 'Change Email',
    href: '/profile/email'
  },
  {
    title: 'Change Phone Number',
    href: '/profile/phone-number'
  },
  {
    title: 'Two-Factor Authentication',
    href: '/profile/two-factor'
  }
];

export function Layout({ children }: LayoutProps) {
  return (
    <ProtectedRoute>
      <BaseLayout>
        <main className='flex h-dvh bg-gray-50'>
          <div className='w-64 bg-white p-4 shadow'>
            <SidebarNav items={sidebarItems} />
          </div>
          <div className='mt-8 w-full'>{children}</div>
        </main>
      </BaseLayout>
    </ProtectedRoute>
  );
}
