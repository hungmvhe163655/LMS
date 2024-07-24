import { Layout } from '@/components/layouts/default-layout';
import { ROLES } from '@/types/constant';

export function VerifyTablePage() {
  return (
    <Layout roles={[ROLES.SUPERVISOR, ROLES.LAB_ADMIN]}>
      <h1 className='mb-4 text-center font-serif text-5xl font-bold'>Verify Accounts</h1>
      <VerifyTablePage />
    </Layout>
  );
}
