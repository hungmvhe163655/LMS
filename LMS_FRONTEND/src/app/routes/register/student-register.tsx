import { Layout } from '@/components/layouts/auth-layout';
import StudentRegisterForm from '@/features/auth/components/student-register-form';

export function StudentRegisterRoute() {
  return (
    <Layout title='Register Your Student Account'>
      <StudentRegisterForm />
    </Layout>
  );
}
