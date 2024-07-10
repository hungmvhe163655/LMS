import useIsAuthenticated from 'react-auth-kit/hooks/useIsAuthenticated';

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
        <ul className='flex space-x-4'>
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
