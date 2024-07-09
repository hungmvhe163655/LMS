import useAuthUser from 'react-auth-kit/hooks/useAuthUser';

import { cn } from '@/lib/utils';
import { User } from '@/types/api';

import { Link } from '../app/link';

export function Logo() {
  const auth = useAuthUser<User>();

  const getRoleLink = () => {
    const userRoles = auth?.roles?.map((role) => role.toLowerCase()) || [];
    if (userRoles.includes('supervisor')) return '/dashboard/supervisor';
    if (userRoles.includes('student')) return '/dashboard/student';
    if (userRoles.includes('labdirector')) return '/dashboard/lab-director';
    return '/';
  };

  return (
    <Link
      to={getRoleLink()}
      className={cn('text-4xl font-bold text-white hover:text-gray-300 hover:no-underline')}
    >
      LMS
    </Link>
  );
}
