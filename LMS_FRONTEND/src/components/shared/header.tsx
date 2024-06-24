import { Link } from '../ui/link';

import { AvatarDropdown } from './avatar-dropdown';
import { Logo } from './logo';
import { NotificationDropdown } from './notification-dropdown';

export function Header() {
  const isLogin = true;

  return (
    <header className='flex items-center justify-between bg-gray-800 p-4'>
      <div>
        <Logo />
      </div>

      {isLogin ? (
        <ul className='flex space-x-4'>
          <li className='my-auto mr-5'>
            <NotificationDropdown />
          </li>
          <li>
            <AvatarDropdown />
          </li>
        </ul>
      ) : (
        <div className='mr-4'>
          <Link
            to='/auth/login'
            className='text-xl font-bold text-white hover:text-gray-300 hover:no-underline'
          >
            Login
          </Link>
        </div>
      )}
    </header>
  );
}
