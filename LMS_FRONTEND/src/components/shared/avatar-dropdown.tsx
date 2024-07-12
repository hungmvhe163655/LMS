import { Bell, LogOut, User } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

import { useLogout } from '@/hooks/use-logout';

import { Avatar, AvatarFallback } from '../ui/avatar';
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger
} from '../ui/dropdown-menu';

export function AvatarDropdown() {
  const navigate = useNavigate();
  const { mutate: logout, isPending } = useLogout();

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Avatar>
          <AvatarFallback className='cursor-pointer text-lg font-bold'>VH</AvatarFallback>
        </Avatar>
      </DropdownMenuTrigger>
      <DropdownMenuContent className='mr-8 w-56'>
        <DropdownMenuLabel>My Account</DropdownMenuLabel>
        <DropdownMenuSeparator />
        <DropdownMenuGroup>
          <DropdownMenuItem onSelect={() => navigate('/profile')}>
            <User className='mr-2 size-4' />
            <span>Profile</span>
          </DropdownMenuItem>
          <DropdownMenuItem>
            <Bell className='mr-2 size-4' />
            <span>Notification</span>
          </DropdownMenuItem>
        </DropdownMenuGroup>
        <DropdownMenuSeparator />

        <DropdownMenuItem
          disabled={isPending}
          onSelect={() =>
            logout(undefined, {
              onSuccess: () => {
                navigate('/');
              }
            })
          }
        >
          <LogOut className='mr-2 size-4' />
          <span>{isPending ? 'Logging out ...' : 'Log out'}</span>
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
