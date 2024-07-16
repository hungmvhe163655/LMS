import WorkspaceLayout from '@/components/layouts/workspace-layout';
import SupervisorDashboard from '@/features/supervisor/supervisor-dashboard';

export function DashboardPage() {
  return (
    <WorkspaceLayout>
      <SupervisorDashboard />
    </WorkspaceLayout>
  );
}
