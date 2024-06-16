import { Layout } from '@/components/layouts/auth-layout';
import ValidateRollNumber from '@/features/auth/components/validate-student-roll-number';

export function ValidateRollNumberRoute() {
  return (
    <Layout title='Validate Your Email'>
      <ValidateRollNumber />
    </Layout>
  );
}
