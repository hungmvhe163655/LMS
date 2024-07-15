import { BaseLayout } from '@/components/layouts/base-layout';
import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectWorkspace from '@/features/project-workspace/project-workspace/components/project-workspace';

export function ProjectWorkspacePage() {
  return (
    <BaseLayout>
      <WorkspaceLayout>
        <ProjectWorkspace />
      </WorkspaceLayout>
    </BaseLayout>
  );
}

export default ProjectWorkspacePage;
