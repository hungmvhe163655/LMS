'use client';

// Import global styles
import '/src/index.css';

// Import necessary components and hooks
import { useState } from 'react';

import Sidenav from '../app/project-workspace-sidebar';

// Define the RootLayout component
export default function WorkspaceLayout({ children }: { children: React.ReactNode }) {
  // State to track whether the sidebar is open or closed
  const [sidebarOpen, setSidebarOpen] = useState(false);

  return (
    <div className='flex h-screen bg-gray-200'>
      <div>
        {/* Render the Sidenav component */}
        <Sidenav sidebarOpen={sidebarOpen} setSidebarOpen={setSidebarOpen} />
      </div>
      <div className='relative flex flex-1 flex-col lg:overflow-y-auto lg:overflow-x-hidden'>
        {/* Render the main content */}
        <main>{children}</main>
      </div>
    </div>
  );
}
