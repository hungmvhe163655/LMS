import { Link } from '../ui/link';

import { Logo } from './logo';

export function Footer() {
  return (
    <footer className='bg-gray-800 text-white'>
      <div className='mx-auto w-full max-w-screen-xl p-4 md:py-4'>
        <div className='sm:flex sm:items-center sm:justify-between'>
          <Logo />
          <ul className='mb-6 flex flex-wrap items-center text-sm font-medium text-gray-500 dark:text-gray-400 sm:mb-0'>
            <li>
              <Link to='#' className='me-4 text-lg font-light md:me-6'>
                About
              </Link>
            </li>
            <li>
              <Link to='#' className='me-4 text-lg font-light md:me-6'>
                Regulation
              </Link>
            </li>
          </ul>
        </div>
        <hr className='my-6 border-gray-200 dark:border-gray-700 sm:mx-auto lg:my-8' />
        <span className='block text-sm text-gray-500 dark:text-gray-400 sm:text-center'>
          © 2024 <Link to='https://fpt.edu.vn/'>FPT University</Link>. All Rights Reserved.
        </span>
      </div>
    </footer>
  );
}
