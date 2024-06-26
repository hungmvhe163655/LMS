import { Layout } from '@/components/layouts/auth-layout';
import LoginForm from '@/features/auth/components/login-form';

export function LoginPage() {
  return (
    <Layout title='Log in to your account'>
      <LoginForm />
    </Layout>
  );
}
