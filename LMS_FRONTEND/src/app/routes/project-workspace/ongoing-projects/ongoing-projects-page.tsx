import { Layout } from '@/components/layouts/default-layout';
import OngoingProjects from '@/features/project-workspace/ongoing-projects/components/ongoing-projects';

export function OngoingProjectsPage() {
  return (
    <Layout>
      <OngoingProjects></OngoingProjects>
    </Layout>
  );
}

export default OngoingProjectsPage;
