'use client';

// Import necessary libraries and components
import { useState, useEffect, useRef } from 'react';
import { Link } from 'react-router-dom';

// Define the Sidenav component
export default function Sidenav({ sidebarOpen, setSidebarOpen }: any) {
  // Define state for sidebar expansion
  const [sidebarExpanded] = useState(false);

  // Create a reference to the sidebar element
  const sidebar = useRef(null);

  // Effect to add or remove a class to the body element based on sidebar expansion
  useEffect(() => {
    if (sidebarExpanded) {
      document.querySelector('body')?.classList.add('sidebar-expanded');
    } else {
      document.querySelector('body')?.classList.remove('sidebar-expanded');
    }
  }, [sidebarExpanded]);

  return (
    <>
      {/* Sidebar backdrop (visible on mobile only) */}
      <div
        onClick={() => setSidebarOpen(!sidebarOpen)}
        className={`fixed inset-0 z-40 border-r border-gray-200 bg-opacity-30 transition-opacity duration-200 sm:translate-x-0 lg:z-auto lg:hidden ${
          sidebarOpen ? 'opacity-100' : 'pointer-events-none opacity-0'
        }`}
        aria-hidden='true'
      ></div>

      {/* Sidebar */}
      <div
        id='sidebar'
        ref={sidebar}
        className={`no-scrollbar lg:sidebar-expanded:w-20 fixed left-0 top-0 z-40 flex h-screen w-72 shrink-0 flex-col overflow-y-scroll border-r border-gray-200 bg-white  p-4 transition-all duration-200 sm:translate-x-0 lg:static lg:left-auto lg:top-auto lg:w-64 lg:translate-x-0 lg:overflow-y-auto ${
          sidebarOpen ? 'translate-x-0' : '-translate-x-72'
        }`}
      >
        {/* Sidebar header */}
        <div className='flex justify-between pr-3 sm:px-2'>
          {/* Sidebar Logo */}
          <Link to='/'>
            <span
              className={`${
                sidebarExpanded ? 'lg:hidden' : 'block'
              }  welcome-step cursor-pointer whitespace-nowrap text-2xl font-medium tracking-tighter text-black focus:outline-none focus:ring`}
            >
              {/* <Image
                className='mt-2 mb-8 h-100 w-32'
                src='/openai.png'
                height={32}
                width={300}
                alt='logo'
              /> */}
            </span>
          </Link>

          {/* Sidebar Icon (Collapsed) */}
          <Link to='/'>
            {/* <Image
              className={`${!sidebarExpanded ? 'lg:hidden' : 'block'} mt-1 mb-8 h-8 w-8`}
              src='/openai-icon.png'
              height={100}
              width={100}
              alt='logo'
            /> */}
          </Link>
        </div>

        {/* Links */}
        <div className='space-y-4'>
          <p
            className={`${
              sidebarExpanded ? 'lg:hidden' : 'block'
            } font-base px-2 text-xs uppercase text-gray-400`}
          >
            Actions
          </p>
          <ul className='space-y-2'>
            <li>
              <Link
                onClick={() => setSidebarOpen(false)}
                to='/jobs'
                className='flex items-center rounded-lg p-2 text-base font-light text-gray-900  hover:bg-gray-100 hover:font-semibold'
              >
                <span className='flex items-center rounded-lg text-base text-gray-900 hover:bg-gray-100  hover:font-semibold'>
                  <svg
                    xmlns='http://www.w3.org/2000/svg'
                    fill='none'
                    viewBox='0 0 24 24'
                    strokeWidth={1.5}
                    stroke='currentColor'
                    className='size-6'
                  >
                    <path
                      strokeLinecap='round'
                      strokeLinejoin='round'
                      d='M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L10.582 16.07a4.5 4.5 0 01-1.897 1.13L6 18l.8-2.685a4.5 4.5 0 011.13-1.897l8.932-8.931zm0 0L19.5 7.125M18 14v4.75A2.25 2.25 0 0115.75 21H5.25A2.25 2.25 0 013 18.75V8.25A2.25 2.25 0 015.25 6H10'
                    />
                  </svg>

                  <span
                    className={`${
                      sidebarExpanded ? 'ml-0 opacity-0 lg:hidden' : 'ml-3 block opacity-100'
                    }ml-3 whitespace-nowrap `}
                  >
                    Write a Blog
                  </span>
                </span>
              </Link>
            </li>
          </ul>
        </div>

        {/* Expand / collapse button */}
        <div className='mt-auto pt-3  lg:inline-flex '>
          <div className='flex-1' />
          <div className='justify-end px-3 py-2'>
            <button onClick={() => setSidebarOpen(false)}>
              <span className='sr-only'>Expand / collapse sidebar</span>
              <svg
                className={`hidden size-6 fill-current lg:block ${!sidebarOpen ? 'rotate-0' : 'rotate-180'}`}
                viewBox='0 0 24 24'
              >
                <path
                  d='M10.5 19.5L3 12M3 12L10.5 4.5M3 12H21'
                  stroke='#0F172A'
                  strokeWidth='1.5'
                  strokeLinecap='round'
                  strokeLinejoin='round'
                />
              </svg>
            </button>
          </div>
        </div>
      </div>
    </>
  );
}
