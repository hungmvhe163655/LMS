'use client';

import { ProtectedRoute } from '@/lib/protected-route';
// Import global styles
import '/src/index.css';

import WorkspaceSidebar from '../app/workspace-sidebar';

import { BaseLayout } from './base-layout';

// Define the RootLayout component
export default function WorkspaceLayout({ children }: { children: React.ReactNode }) {
  return (
    <ProtectedRoute>
      <BaseLayout>
        <main className='flex flex-1 bg-gray-50'>
          <WorkspaceSidebar />
          {children}
        </main>
      </BaseLayout>
    </ProtectedRoute>
  );
}
