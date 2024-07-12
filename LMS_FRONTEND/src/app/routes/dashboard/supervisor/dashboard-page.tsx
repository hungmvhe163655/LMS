import WorkspaceLayout from '@/components/layouts/workspace-layout';
import SupervisorDashboard from '@/features/supervisor/supervisor-dashboard';

export function SupervisorDashboardPage() {
  return (
    <WorkspaceLayout>
      <SupervisorDashboard />
    </WorkspaceLayout>
  );
}
