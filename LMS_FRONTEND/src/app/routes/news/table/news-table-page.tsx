import { Layout } from '@/components/layouts/default-layout';
import { Head } from '@/components/seo/head';
import { NewsTable } from '@/features/news/components/news-table';

export function NewsTablePage() {
  return (
    <Layout>
      <Head title={'News'} />
      <h1 className='mb-4 text-center font-serif text-5xl font-bold'>News</h1>
      <NewsTable />
    </Layout>
  );
}
