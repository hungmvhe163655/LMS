import WorkspaceLayout from '@/components/layouts/workspace-layout';
import StudentDashboard from '@/features/student/student-dashboard';

export function StudentDashboardPage() {
  return (
    <WorkspaceLayout>
      <StudentDashboard />
    </WorkspaceLayout>
  );
}
