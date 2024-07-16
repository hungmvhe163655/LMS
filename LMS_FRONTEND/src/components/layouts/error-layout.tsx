import { Link } from '../app/link';
import { Head } from '../seo/head';

import { BaseLayout } from './base-layout';

type LayoutProps = {
  title: string;
  message: string;
};

export function Layout({ title, message }: LayoutProps) {
  return (
    <BaseLayout>
      <Head title={'error'} />
      <main className='m-auto flex h-dvh items-center justify-center font-semibold'>
        <div className='text-center'>
          <h1 className='text-4xl text-red-500'>{title}</h1>
          <p className='my-2'>{message}</p>
          <Link to='/' replace>
            Go to Home
          </Link>
        </div>
      </main>
    </BaseLayout>
  );
}
