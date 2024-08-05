import { BaseLayout } from '@/components/layouts/base-layout';
import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectSettings from '@/features/project-workspace/project-settings/components/project-settings';

export function ProjectSettingsPage() {
  return (
    <BaseLayout>
      <WorkspaceLayout>
        <ProjectSettings />
      </WorkspaceLayout>
    </BaseLayout>
  );
}

export default ProjectSettingsPage;
