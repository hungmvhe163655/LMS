import { Navigate, useLocation } from 'react-router-dom';

import { Layout } from '@/components/layouts/auth-layout';
import NotVerifiedForm from '@/features/auth/components/not-verfied-form';

export function NotVerifiedPage() {
  const location = useLocation();
  const errorData = location.state?.errorData;

  if (!errorData) {
    return <Navigate to='/' />;
  }

  return (
    <Layout title='Not Verfied!'>
      <NotVerifiedForm accountId={errorData.accountId} verifierId={errorData.verifierId} />
    </Layout>
  );
}
