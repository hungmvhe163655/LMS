import { Layout } from '@/components/layouts/profile-layout';
import { ChangeEmailForm } from '@/features/profile/components/change-email-form';

export function EmailPage() {
  return (
    <Layout>
      <ChangeEmailForm />
    </Layout>
  );
}
