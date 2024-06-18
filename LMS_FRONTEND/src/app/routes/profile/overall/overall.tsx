import { Layout } from '@/components/layouts/profile-layout';
import { ImportantInfo } from '@/features/profile/components/important-info';
import { Info } from '@/features/profile/components/info';

export function Overall() {
  return (
    <Layout>
      <Info />
      <ImportantInfo />
    </Layout>
  );
}
