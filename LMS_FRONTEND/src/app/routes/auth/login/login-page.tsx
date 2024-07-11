import useAuthUser from 'react-auth-kit/hooks/useAuthUser';
import { Navigate } from 'react-router-dom';

import { Layout } from '@/components/layouts/auth-layout';
import LoginForm from '@/features/auth/components/login-form';
import { UserLogin } from '@/types/api';
import getRedirectBasedOnRoles from '@/utils/role-based-redirect';

export function LoginPage() {
  const auth = useAuthUser<UserLogin>();
  if (auth) {
    const link = getRedirectBasedOnRoles(auth.roles);
    return <Navigate to={link} />;
  }

  return (
    <Layout title='Log in to your account'>
      <LoginForm />
    </Layout>
  );
}
