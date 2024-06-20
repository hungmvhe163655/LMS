import { DashboardLayout } from '@/components/layouts/dashboard-layout';
import StudentDashboard from '@/features/student/student-dashboard';

export function StudentDashboardPage() {
  return (
    <DashboardLayout title='Student Dashboard'>
      <StudentDashboard />
    </DashboardLayout>
  );
}
