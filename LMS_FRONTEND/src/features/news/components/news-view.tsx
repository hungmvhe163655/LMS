import parse from 'html-react-parser';
import DOMPurify from 'isomorphic-dompurify';

import { Spinner } from '@/components/app/spinner';

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

  if (!data) return null;

  const clean = DOMPurify.sanitize(data.content, { USE_PROFILES: { html: true } });

  return <div>{parse(clean)}</div>;
}
