import WorkspaceLayout from '@/components/layouts/workspace-layout';
import ProjectTaskManager from '@/features/project-workspace/project-tasks-manager/components/project-tasks-manager';

export function ListProjectTasksPage() {
  return (
    <WorkspaceLayout>
      <ProjectTaskManager />
    </WorkspaceLayout>
  );
}

export default ListProjectTasksPage;
