import { Link } from '../ui/link';

import { AvatarDropdown } from './avatar-dropdown';

export function Header() {
  const isLogin = false;

  return (
    <header className='flex items-center justify-between bg-gray-800 p-4'>
      <div>
        <Link to='/' className='text-2xl font-bold text-slate-600 hover:text-gray-300'>
          LMS
        </Link>
      </div>
      <ul>
        {isLogin ? (
          <li>
            <AvatarDropdown />
          </li>
        ) : (
          <li>
            <Link to='/auth/login' className='text-white hover:text-gray-400'>
              Login
            </Link>
          </li>
        )}
      </ul>
    </header>
  );
}
