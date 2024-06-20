import { Layout } from '@/components/layouts/profile-layout';
import { ImportantInfo } from '@/features/profile/components/important-info';
import { Info } from '@/features/profile/components/info';

export function OverallPage() {
  return (
    <Layout>
      <Info />
      <ImportantInfo />
    </Layout>
  );
}
