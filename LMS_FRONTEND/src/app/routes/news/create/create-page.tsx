import { Layout } from '@/components/layouts/default-layout';
import { CreateNewsForm } from '@/features/news/components/create-news';

export function CreateNewsPage() {
  return (
    <Layout>
      <CreateNewsForm />
    </Layout>
  );
}
