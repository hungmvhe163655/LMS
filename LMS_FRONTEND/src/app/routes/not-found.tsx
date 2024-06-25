import { Link } from '@/components/app/link';
import { BaseLayout } from '@/components/layouts/base-layout';

export function NotFoundRoute() {
  return (
    <BaseLayout>
      <div className='my-44 flex flex-col items-center font-semibold'>
        <h1>404 - Not Found</h1>
        <p>Sorry, the page you are looking for does not exist.</p>
        <Link to='/' replace>
          Go to Home
        </Link>
      </div>
    </BaseLayout>
  );
}
