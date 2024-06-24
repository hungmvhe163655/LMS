import { Layout } from '@/components/layouts/profile-layout';
import { ChangePasswordForm } from '@/features/profile/components/change-password-form';

export function PasswordPage() {
  return (
    <Layout>
      <ChangePasswordForm />
    </Layout>
  );
}
