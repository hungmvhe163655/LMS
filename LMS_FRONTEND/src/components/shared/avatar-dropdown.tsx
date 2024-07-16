import { Bell, LogOut, User } from 'lucide-react';
import { useNavigate } from 'react-router-dom';

import useAvatar from '@/hooks/use-avatar';
import { useLogout } from '@/hooks/use-logout';
import { authStore } from '@/lib/auth-store';
import { LoginData } from '@/types/api';

import { Avatar, AvatarImage } from '../ui/avatar';
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
  const { accessData, clearAccessData } = authStore.getState();
  const auth = accessData as LoginData;
  const url = useAvatar(auth?.id);

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Avatar className='select-none hover:cursor-pointer'>
          <AvatarImage src={url} />
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
                clearAccessData();
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
