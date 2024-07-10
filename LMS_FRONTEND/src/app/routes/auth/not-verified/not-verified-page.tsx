import { Layout } from '@/components/layouts/auth-layout';
import NotVerifiedForm from '@/features/auth/components/not-verfied-form';

export function NotVerifiedPage() {
  return (
    <Layout title='Your Account is Not Verfied Yet!'>
      <NotVerifiedForm />
    </Layout>
  );
}
