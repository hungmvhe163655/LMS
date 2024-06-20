import { Layout } from '@/components/layouts/profile-layout';
import { ChangePhoneNumberForm } from '@/features/profile/components/change-phone-number-form';

export function PhoneNumberPage() {
  return (
    <Layout>
      <ChangePhoneNumberForm />
    </Layout>
  );
}
