import { Layout } from '@/components/layouts/auth-layout';
import ChooseRoleRegister from '@/features/auth/components/choose-role';

export function ChooseRolePage() {
  return (
    <Layout title='You are ...'>
      <ChooseRoleRegister />
    </Layout>
  );
}
