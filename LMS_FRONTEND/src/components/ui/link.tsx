import { Link as RouterLink, LinkProps } from 'react-router-dom';

import { cn } from '@/lib/utils';

export const Link = ({ className, children, ...props }: LinkProps) => {
  return (
    <RouterLink className={cn('text-cyan-400 hover:text-cyan-600', className)} {...props}>
      {children}
    </RouterLink>
  );
};
