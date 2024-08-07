import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectWorkspace from '@/features/project-workspace/project-workspace/components/project-workspace';

export function ProjectWorkspacePage() {
  return (
    <WorkspaceLayout>
      <ProjectWorkspace />
    </WorkspaceLayout>
  );
}

export default ProjectWorkspacePage;
