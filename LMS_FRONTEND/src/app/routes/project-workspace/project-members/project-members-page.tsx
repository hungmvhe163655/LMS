import { BaseLayout } from '@/components/layouts/base-layout';
import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectMembers from '@/features/project-workspace/project-members/components/project-members';

export function ProjectMembersPage() {
  return (
    <BaseLayout>
      <WorkspaceLayout>
        <ProjectMembers />
      </WorkspaceLayout>
    </BaseLayout>
  );
}

export default ProjectMembersPage;
