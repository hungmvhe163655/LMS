import { BaseLayout } from '@/components/layouts/base-layout';
import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectTaskManager from '@/features/project-workspace/project-tasks-manager/components/project-tasks-manager';

export function ListProjectTasksPage() {
  return (
    <BaseLayout>
      <WorkspaceLayout>
        <ProjectTaskManager />
      </WorkspaceLayout>
    </BaseLayout>
  );
}

export default ListProjectTasksPage;
