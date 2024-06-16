import { Layout } from '@/components/layouts/auth-layout';
import CreateNews from '@/features/News/create-news';

export function CreateNewsRoute() {
  return (
    <Layout title='Create news'>
      <CreateNews />
    </Layout>
  );
}
