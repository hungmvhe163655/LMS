import { ErrorFallback } from '@/components/errors/error-fallback';
import { Layout } from '@/components/layouts/error-layout';

export function BannedPage() {
  return (
    <Layout>
      <ErrorFallback title='Banned' message='Your account is banned from this LAB!' />
    </Layout>
  );
}
