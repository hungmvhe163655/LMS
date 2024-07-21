import { useParams } from 'react-router-dom';

import { Layout } from '@/components/layouts/default-layout';
import { NewsView } from '@/features/news/components/news-view';

export function NewsDetailPage() {
  const { id } = useParams() as { id: string };

  return (
    <Layout>
      <NewsView id={id} />
    </Layout>
  );
}
