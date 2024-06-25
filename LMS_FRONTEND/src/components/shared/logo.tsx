import { Link } from '../app/link';

import { cn } from '@/lib/utils';

export function Logo() {
  return (
    <Link
      to='/'
      className={cn('text-4xl font-bold text-white hover:text-gray-300 hover:no-underline')}
    >
      LMS
    </Link>
  );
}
