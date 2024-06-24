import { Layout } from '@/components/layouts/auth-layout';
import CreateForm from '@/features/news/components/create-form';

export function CreateNewsPage() {
  return (
    <Layout title='Create news'>
      <CreateForm />
    </Layout>
  );
}
