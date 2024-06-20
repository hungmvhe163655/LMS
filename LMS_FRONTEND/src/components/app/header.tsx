import { Avatar, AvatarFallback } from '../ui/avatar';
import { Link } from '../ui/link';

function Header() {
  return (
    <header className='flex items-center justify-between bg-gray-800 p-4'>
      <div>
        <Link to='/' className='text-2xl font-bold hover:text-gray-300'>
          LMS
        </Link>
      </div>
      <ul>
        <li>
          <Avatar>
            <AvatarFallback className='text-sm'>VH</AvatarFallback>
          </Avatar>
        </li>
      </ul>
    </header>
  );
}

export default Header;
