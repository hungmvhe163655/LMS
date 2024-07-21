import { NotFoundFallback } from '@/components/errors/not-found';
import { Layout } from '@/components/layouts/error-layout';

export function NotFoundPage() {
  return (
    <Layout>
      <NotFoundFallback
        title='404 - Not Found'
        message='Sorry, the page you are looking for does not exist.'
      />
    </Layout>
  );
}
