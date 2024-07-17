import { Navigate } from 'react-router-dom';

import { Layout } from '@/components/layouts/auth-layout';
import LoginForm from '@/features/auth/components/login-form';
import { authStore } from '@/lib/auth-store';
import getRedirectBasedOnRoles from '@/utils/role-based-redirect';

export function LoginPage() {
  const { accessData } = authStore.getState();
  if (accessData) {
    const link = getRedirectBasedOnRoles(accessData.roles);
    return <Navigate to={link} />;
  }

  return (
    <Layout title='Log in to your account'>
      <LoginForm />
    </Layout>
  );
}
