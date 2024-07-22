import parse from 'html-react-parser';
import DOMPurify from 'isomorphic-dompurify';

import { Link } from '@/components/app/link';
import { Spinner } from '@/components/app/spinner';
import { NotFoundFallback } from '@/components/errors/not-found';
import { formatDateNoHours } from '@/utils/format';

import { useNewsById } from '../api/get-news-id';

export function NewsView({ id }: { id: string }) {
  const { data, isLoading } = useNewsById({ id });

  if (isLoading) {
    return (
      <div className='flex h-48 w-full items-center justify-center'>
        <Spinner size='lg' />
      </div>
    );
  }

  if (!data)
    return (
      <NotFoundFallback
        title='404 - Not Found'
        message='Sorry, the news page you are looking for does not exist.'
      />
    );

  const clean = DOMPurify.sanitize(data.content, { USE_PROFILES: { html: true } });

  return (
    <div className='relative w-full bg-white px-6 py-10 shadow-xl shadow-slate-700/10 ring-1 ring-gray-900/5 md:mx-auto md:max-w-3xl lg:max-w-4xl lg:py-16'>
      <article className='prose prose-slate mx-auto lg:prose-xl prose-a:text-blue-600 prose-img:rounded-xl'>
        <h1>{data.title}</h1>
        <div className='not-prose flex items-center justify-between'>
          <p className='font-serif'>By: {data.createdBy}</p>
          <p className='font-serif font-normal italic'>
            Date: {formatDateNoHours(data.createdDate)}
          </p>
        </div>
        <div>{parse(clean)}</div>
        <div className='flex justify-between'>
          <Link className='not-prose font-serif' to='/news'>
            See List News
          </Link>
          <Link className='not-prose' variant='button' to='/'>
            Return to Dashboard
          </Link>
        </div>
      </article>
    </div>
  );
}
