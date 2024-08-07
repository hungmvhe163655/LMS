import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectSettings from '@/features/project-workspace/project-settings/components/project-settings';

export function ProjectSettingsPage() {
  return (
    <WorkspaceLayout>
      <ProjectSettings />
    </WorkspaceLayout>
  );
}

export default ProjectSettingsPage;
