import { Layout } from '@/components/layouts/auth-layout';
import ValidateEmail from '@/features/auth/components/validate-email';

export function ValidateEmailPage() {
  return (
    <Layout title='Validate Your Email'>
      <ValidateEmail />
    </Layout>
  );
}
