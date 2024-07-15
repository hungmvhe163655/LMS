import { useAccessData } from '@/lib/auth-store';
import { cn } from '@/lib/utils';
import getRedirectBasedOnRoles from '@/utils/role-based-redirect';

import { Link } from '../app/link';

export function Logo() {
  const auth = useAccessData();
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
