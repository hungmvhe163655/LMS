import { BaseLayout } from '@/components/layouts/base-layout';
import WorkspaceLayout from '@/components/layouts/workspace-layout';
import { ListAllTasks } from '@/features/project-workspace/list-all-tasks/components/list-all-tasks';

export function ListAllTasksPage() {
  return (
    <BaseLayout>
      <WorkspaceLayout>
        <ListAllTasks />
      </WorkspaceLayout>
    </BaseLayout>
  );
}

export default ListAllTasksPage;
