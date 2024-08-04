import { BannedAccount } from '@/components/errors/banned-account';
import { Layout } from '@/components/layouts/auth-layout';

export function NotVerifiedPage() {
  return (
    <Layout title='BANNED ACCOUNT!'>
      <BannedAccount />
    </Layout>
  );
}
