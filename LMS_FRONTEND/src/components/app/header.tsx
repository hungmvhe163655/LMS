import * as React from 'react';

import { Link } from '../ui/link';

interface HeaderProps {
  title: string;
}

const Header: React.FC<HeaderProps> = ({ title }) => {
  return (
    <header className='bg-gray-800 p-4 text-white'>
      <div className='container mx-auto flex items-center justify-between'>
        <h1 className='text-lg font-bold'>{title}</h1>
        <ul className='flex space-x-4'>
          <li>
            <Link to='/' className='hover:text-gray-300'>
              Home
            </Link>
          </li>
          <li>
            <Link to='/about' className='hover:text-gray-300'>
              About
            </Link>
          </li>
          <li>
            <Link to='/contact' className='hover:text-gray-300'>
              Contact
            </Link>
          </li>
        </ul>
      </div>
    </header>
  );
};

export default Header;
