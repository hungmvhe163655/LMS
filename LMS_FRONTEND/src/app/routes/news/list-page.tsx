import { Layout } from '@/components/layouts/default-layout';
import { NewsTable } from '@/features/news/components/news-table';

export function ListNewsPage() {
  return (
    <Layout>
      <NewsTable />
    </Layout>
  );
}
