import { useNavigate, useSearchParams } from 'react-router-dom';

import { Layout } from '@/components/layouts/auth-layout';
import LoginForm from '@/features/auth/components/login-form';
import { User } from '@/types/api';

export function LoginPage() {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const redirectTo = searchParams.get('redirectTo');

  const handleSuccess = (data: User | undefined) => {
    console.log(data);
    if (data) {
      const { roles } = data;

      if (roles && redirectTo) {
        navigate(redirectTo ? redirectTo : '/', { replace: true });
      } else if (roles.includes('Supervisor')) {
        navigate('/dashboard/supervisor');
      } else if (roles.includes('Student')) {
        navigate('/dashboard/student');
      } else if (roles.includes('Lab Director')) {
        navigate('/dashboard/lab-director');
      }
    }
  };

  return (
    <Layout title='Log in to your account'>
      <LoginForm onSuccess={handleSuccess} />
    </Layout>
  );
}
