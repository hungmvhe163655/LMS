import { Layout } from '@/components/layouts/auth-layout';
import SupervisorRegisterForm from '@/features/auth/components/supervisor-register-form';

export function SupervisorRegisterRoute() {
  return (
    <Layout title='Register Your Supervisor Account'>
      <SupervisorRegisterForm />
    </Layout>
  );
}
