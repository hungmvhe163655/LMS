import { ErrorFallback } from '@/components/errors/error-fallback';
import { Layout } from '@/components/layouts/error-layout';

export function NotFoundPage() {
  return (
    <Layout>
      <ErrorFallback
        title='404 - Not Found'
        message='Sorry, the page you are looking for does not exist.'
      />
    </Layout>
  );
}
