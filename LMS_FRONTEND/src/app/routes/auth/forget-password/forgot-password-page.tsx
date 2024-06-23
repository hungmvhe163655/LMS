import { Layout } from '@/components/layouts/auth-layout';
import ForgotPassword from '@/features/auth/components/forgot-password-form';

export function ForgotPasswordPage() {
  return (
    <Layout title='Forgot your password?'>
      <ForgotPassword />
    </Layout>
  );
}
