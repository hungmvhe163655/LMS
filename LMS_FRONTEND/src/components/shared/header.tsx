import useIsAuthenticated from 'react-auth-kit/hooks/useIsAuthenticated';

import { Link } from '../app/link';

import { AvatarDropdown } from './avatar-dropdown';
import { Logo } from './logo';
import { NotificationDropdown } from './notification-dropdown';

export function Header() {
  const isLogin = useIsAuthenticated();

  return (
    <header className='flex items-center justify-between bg-gray-800 p-4'>
      <div className='ml-10'>
        <Logo />
      </div>

      {isLogin && (
        <ul className='flex justify-center space-x-10 align-middle'>
          <Link
            to={'/news'}
            className='my-auto font-serif text-2xl text-white hover:text-gray-400 hover:no-underline'
          >
            News{' '}
          </Link>
          <li className='my-auto mr-5'>
            <NotificationDropdown />
          </li>
          <li>
            <AvatarDropdown />
          </li>
        </ul>
      )}
    </header>
  );
}
