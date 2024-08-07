import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectMembers from '@/features/project-workspace/project-members/components/project-members';

export function ProjectMembersPage() {
  return (
    <WorkspaceLayout>
      <ProjectMembers />
    </WorkspaceLayout>
  );
}

export default ProjectMembersPage;
