import { Layout } from '@/components/layouts/default-layout';
import { ResourceTable } from '@/features/project-resources/components/resource-table';

export function ProjectResourcesTablePage() {
  return (
    <Layout>
      <ResourceTable />
    </Layout>
  );
}
