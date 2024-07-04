import { Bell, LogOut, User } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

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

import { useLogout } from '@/lib/auth';

interface AvatarDropdownProps {
  avatarName: string;
}

export function AvatarDropdown({ avatarName }: AvatarDropdownProps) {
  const navigate = useNavigate();
  const logout = useLogout();

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Avatar>
          <AvatarFallback className='cursor-pointer text-lg font-bold'>{avatarName}</AvatarFallback>
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

        <DropdownMenuItem onSelect={() => logout.mutate({})}>
          <LogOut className='mr-2 size-4' />
          <span>Log out</span>
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}
