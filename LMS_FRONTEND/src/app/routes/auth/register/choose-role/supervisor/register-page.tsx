import { Layout } from '@/components/layouts/auth-layout';
import SupervisorRegisterForm from '@/features/auth/components/supervisor-register-form';

export function SupervisorRegisterPage() {
  return (
    <Layout title='Register as Supervisor'>
      <SupervisorRegisterForm />
    </Layout>
  );
}
