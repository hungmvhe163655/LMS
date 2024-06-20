import { cn } from '@/lib/utils';

import { Link } from '../ui/link';

export function Logo() {
  return (
    <Link to='/' className={cn('text-4xl font-bold text-slate-400 hover:text-gray-300')}>
      LMS
    </Link>
  );
}
