import { Link, useLocation } from 'react-router-dom';

import { SidebarNavProps } from '../types/type';

import { cn } from '@/lib/utils';

export function SidebarNav({ items }: SidebarNavProps) {
  const location = useLocation();

  return items.length ? (
    <div className='grid grid-flow-row auto-rows-max text-sm'>
      {items.map((item, index) =>
        !item.disabled && item.href ? (
          <Link
            key={index}
            to={item.href}
            className={cn('flex w-full items-center rounded-md p-2 hover:bg-muted', {
              'bg-muted font-bold m-2': location.pathname === item.href
            })}
            target={item.external ? '_blank' : ''}
            rel={item.external ? 'noreferrer' : ''}
          >
            {item.title}
          </Link>
        ) : (
          <span
            key={index}
            className='m-2 flex w-full cursor-not-allowed items-center rounded-md p-2 opacity-60'
          >
            {item.title}
          </span>
        )
      )}
    </div>
  ) : null;
}
