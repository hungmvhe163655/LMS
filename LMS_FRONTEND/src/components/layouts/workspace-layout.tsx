'use client';

// eslint-disable-next-line import/order
import { ProtectedRoute } from '@/lib/protected-route';
// Import global styles
import '/src/index.css';

// eslint-disable-next-line import/order
import WorkspaceSidebar from '../app/workspace-sidebar';

// Define the RootLayout component
export default function WorkspaceLayout({ children }: { children: React.ReactNode }) {
  return (
    <ProtectedRoute>
      <main className='flex h-dvh bg-gray-50'>
        <WorkspaceSidebar />
        <div className='mt-8 w-full'>{children}</div>
      </main>
    </ProtectedRoute>
  );
}
