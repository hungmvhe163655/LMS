import { Layout } from '@/components/layouts/auth-layout';
import CreateNews from '@/features/news/create-news';

export function CreateNewsRoute() {
  return (
    <Layout title='Create news'>
      <CreateNews />
    </Layout>
  );
}
