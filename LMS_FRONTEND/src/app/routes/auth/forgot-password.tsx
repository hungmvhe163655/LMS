import { Layout } from '@/components/layouts/auth-layout';
import ForgotPassword from '@/features/auth/components/forgot-password-form';

export function ForgotPasswordRoute() {
  return (
    <Layout title='Forgot your password?'>
      <ForgotPassword></ForgotPassword>
    </Layout>
  );
}
