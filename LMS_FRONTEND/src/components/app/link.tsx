import { cva } from 'class-variance-authority';
import React from 'react';
import { Link as RouterLink, LinkProps } from 'react-router-dom';

import { cn } from '@/lib/utils';

// Define the linkVariants using cva
const linkVariants = cva('transition-all', {
  variants: {
    variant: {
      default: 'text-sky-500 hover:text-sky-800 hover:underline',
      button:
        'rounded-lg bg-blue-700 px-5 py-2.5 text-sm font-medium text-white hover:bg-blue-800 focus:outline-none focus:ring-4 focus:ring-blue-300'
    }
  },
  defaultVariants: {
    variant: 'default'
  }
});

interface CustomLinkProps extends LinkProps {
  variant?: 'default' | 'button';
}

// eslint-disable-next-line react/display-name
export const Link = React.forwardRef<HTMLAnchorElement, CustomLinkProps>(
  ({ className, children, variant = 'default', ...props }, ref) => {
    return (
      <RouterLink ref={ref} className={cn(linkVariants({ variant }), className)} {...props}>
        {children}
      </RouterLink>
    );
  }
);
