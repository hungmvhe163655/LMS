import { Layout } from '@/components/layouts/default-layout';
import { ResourceTable } from '@/features/project-resources/components/resource-table';

export function ProjectResourcesTablePage() {
  return (
    <Layout>
      <h1 className='mb-4 text-center font-serif text-5xl font-bold'>Resouces</h1>
      <ResourceTable />
    </Layout>
  );
}
