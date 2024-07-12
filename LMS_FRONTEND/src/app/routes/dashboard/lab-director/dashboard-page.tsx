import WorkspaceLayout from '@/components/layouts/workspace-layout';
import LabDirectorDashboard from '@/features/lab-director/lab-director-dashboard';

export function LabDirectorDashboardPage() {
  return (
    <WorkspaceLayout>
      <LabDirectorDashboard />
    </WorkspaceLayout>
  );
}
