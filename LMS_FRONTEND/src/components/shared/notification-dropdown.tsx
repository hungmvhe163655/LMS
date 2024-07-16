import { Bell, User } from 'lucide-react';

import { Link } from '../app/link';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger
} from '../ui/dropdown-menu';

export function NotificationDropdown() {
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <div className='relative'>
          <Bell className='size-6 cursor-pointer text-white' />
          <span className='absolute -right-1 -top-1 flex size-4 items-center justify-center rounded-full bg-red-500 text-xs font-bold'></span>
        </div>
      </DropdownMenuTrigger>
      <DropdownMenuContent className='mr-8 mt-1 w-auto min-w-full' align='end'>
        <DropdownMenuLabel className='flex justify-between'>
          <div>Notification</div>
          <Link to='#'>View All</Link>
        </DropdownMenuLabel>
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <DropdownMenuItem>
            <User className='mr-2 size-4' />
            <span>Profile</span>
          </DropdownMenuItem>
          <DropdownMenuItem>
            <span>Notification</span>
          </DropdownMenuItem>
        </DropdownMenuGroup>

        <DropdownMenuSeparator />
        <Link to='#'>
          <DropdownMenuItem className='justify-center'>View More</DropdownMenuItem>
        </Link>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
