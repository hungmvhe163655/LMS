import { Link } from '../ui/link';

import { AvatarDropdown } from './avatar-dropdown';
import { Logo } from './logo';

export function Header() {
  const isLogin = true;

  return (
    <header className='flex items-center justify-between bg-gray-800 p-4'>
      <div>
        <Logo />
      </div>
      <ul>
        {isLogin ? (
          <li className='mr-4'>
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
