import { BaseLayout } from '@/components/layouts/base-layout';
import WorkspaceLayout from '@/components/layouts/workspace-layout';
import OngoingProjects from '@/features/project-workspace/ongoing-projects/components/ongoing-projects';

export function OngoingProjectsPage() {
  return (
    <BaseLayout>
      <WorkspaceLayout>
        <OngoingProjects></OngoingProjects>
      </WorkspaceLayout>
    </BaseLayout>
  );
}

export default OngoingProjectsPage;
