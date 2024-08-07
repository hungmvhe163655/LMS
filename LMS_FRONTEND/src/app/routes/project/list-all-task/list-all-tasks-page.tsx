import WorkspaceLayout from '@/components/layouts/workspace-layout';
import { ListAllTasks } from '@/features/project-workspace/list-all-tasks/components/list-all-tasks';

export function ListAllTasksPage() {
  return (
    <WorkspaceLayout>
      <ListAllTasks />
    </WorkspaceLayout>
  );
}

export default ListAllTasksPage;
