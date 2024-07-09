import useAuthUser from 'react-auth-kit/hooks/useAuthUser';

import useRoleBasedRedirect from '@/hooks/use-role-based-redirect';
import { cn } from '@/lib/utils';
import { User } from '@/types/api';

import { Link } from '../app/link';

export function Logo() {
  const auth = useAuthUser<User>() as User;
  const { getRedirectBasedOnRoles } = useRoleBasedRedirect(auth);

  return (
    <Link
      to={getRedirectBasedOnRoles()}
      className={cn('text-4xl font-bold text-white hover:text-gray-300 hover:no-underline')}
    >
      LMS
    </Link>
  );
}
