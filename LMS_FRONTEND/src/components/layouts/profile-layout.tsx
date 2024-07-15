import { ProfileSidebar } from '@/features/profile/components/profile-sidebar';
import { ProtectedRoute } from '@/lib/protected-route';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  children: React.ReactNode;
};

export function Layout({ children }: LayoutProps) {
  return (
    <ProtectedRoute>
      <BaseLayout>
        <main className='flex h-dvh bg-gray-50'>
          <ProfileSidebar />
          <div className='mt-8 w-full'>{children}</div>
        </main>
      </BaseLayout>
    </ProtectedRoute>
  );
}
