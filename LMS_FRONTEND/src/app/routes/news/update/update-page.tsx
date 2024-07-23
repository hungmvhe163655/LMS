import { useParams } from 'react-router-dom';

import { Layout } from '@/components/layouts/default-layout';
import { UpdateNewsForm } from '@/features/news/components/update-news';

export function UpdateNewsPage() {
  const { id } = useParams() as { id: string };

  return (
    <Layout>
      <UpdateNewsForm id={id} />
    </Layout>
  );
}
