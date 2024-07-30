import { BaseLayout } from '@/components/layouts/base-layout';
import BookingSchedule from '@/features/device/booking-schedule/components/booking-schedule';

export function BookingSchedulePage() {
  return (
    <BaseLayout>
      <BookingSchedule></BookingSchedule>
    </BaseLayout>
  );
}

export default BookingSchedulePage;
