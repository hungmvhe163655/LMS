import { Layout } from '@/components/layouts/auth-layout';
import ListNews from '@/features/news/list-news';

export function ListNewsRoute() {
  return (
    <Layout title='News List'>
      <ListNews />
    </Layout>
  );
}
