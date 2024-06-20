import { DashboardLayout } from '@/components/layouts/dashboard-layout';
import StudentDashboard from '@/features/student/student-dashboard';

export function StudentDashboardRoute() {
  return (
    <DashboardLayout title='Student Dashboard'>
      <StudentDashboard />
    </DashboardLayout>
  );
}
