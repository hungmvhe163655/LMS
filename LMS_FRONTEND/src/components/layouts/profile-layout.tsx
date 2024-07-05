import { BaseLayout } from './base-layout';

import { SidebarNav } from '@/features/profile/components/sidebar';
import { SidebarNavItem } from '@/features/profile/types/type';
import { ProtectedRoute } from '@/lib/auth';

type LayoutProps = {
  children: React.ReactNode;
};

const sidebarItems: SidebarNavItem[] = [
  {
    title: 'Overall',
    href: '/profile/overall'
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
        <div className='flex min-h-screen bg-gray-50'>
          <div className='w-64 bg-white p-4 shadow'>
            <SidebarNav items={sidebarItems} />
          </div>
          <div className='mt-8 w-full'>{children}</div>
        </div>
      </BaseLayout>
    </ProtectedRoute>
  );
}
