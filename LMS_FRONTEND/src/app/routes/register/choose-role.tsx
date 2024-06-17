import { Layout } from '@/components/layouts/auth-layout';
import ChooseRoleRegister from '@/features/auth/components/choose-role';

export function ChooseRoleRoute() {
  return (
    <Layout title='You are ...'>
      <ChooseRoleRegister></ChooseRoleRegister>
    </Layout>
  );
}
