import useAuthUser from 'react-auth-kit/hooks/useAuthUser';

import { cn } from '@/lib/utils';
import { UserLogin } from '@/types/api';
import getRedirectBasedOnRoles from '@/utils/role-based-redirect';

import { Link } from '../app/link';

export function Logo() {
  const auth = useAuthUser<UserLogin>();
  const link = auth ? getRedirectBasedOnRoles(auth.roles) : '/';

  return (
    <Link
      to={link}
      className={cn('text-4xl font-bold text-white hover:text-gray-300 hover:no-underline')}
    >
      LMS
    </Link>
  );
}
