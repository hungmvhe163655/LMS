import { Link } from '../app/link';

export function Footer() {
  return (
    <footer className='mt-auto bg-gray-800 text-white'>
      <div className='mx-auto w-full max-w-screen-xl p-2'>
        <hr className='my-4 border-gray-200 sm:mx-auto dark:border-gray-700' />
        <span className='block text-sm text-gray-500 sm:text-center dark:text-gray-400'>
          © 2024 <Link to='https://fpt.edu.vn/'>FPT University</Link>. All Rights Reserved.
        </span>
      </div>
    </footer>
  );
}
