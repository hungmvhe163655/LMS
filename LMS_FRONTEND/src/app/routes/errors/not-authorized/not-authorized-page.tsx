import { ErrorFallback } from '@/components/errors/error-fallback';
import { Layout } from '@/components/layouts/error-layout';

export function NotAuthorizedPage() {
  return (
    <Layout>
      <ErrorFallback
        title='Not Authorized'
        message='Sorry, you are not allowed to visit this page!'
      />
    </Layout>
  );
}
