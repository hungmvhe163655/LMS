import { Layout } from '@/components/layouts/auth-layout';
import CreateNews from '@/features/news/create-news';

export function CreateNewsPage() {
  return (
    <Layout title='Create news'>
      <CreateNews />
    </Layout>
  );
}
