import { Link } from '@/components/app/link';

export function NewsTableToolbarActions() {
  return (
    <div className='flex items-center gap-2'>
      <Link
        to='/news/create'
        className='rounded-lg bg-blue-700 px-5 py-2.5 text-sm font-medium text-white hover:bg-blue-800 focus:outline-none focus:ring-4 focus:ring-blue-300'
      >
        Create News
      </Link>
    </div>
  );
}
