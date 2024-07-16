import { Link } from '../app/link';

export function Footer() {
  return (
    <footer className='bg-gray-800 text-white'>
      <div className='mx-auto w-full max-w-screen-xl p-2'>
        <hr className='my-4 border-gray-200 dark:border-gray-700 sm:mx-auto' />
        <span className='block text-sm text-gray-500 dark:text-gray-400 sm:text-center'>
          © 2024 <Link to='https://fpt.edu.vn/'>FPT University</Link>. All Rights Reserved.
        </span>
      </div>
    </footer>
  );
}
