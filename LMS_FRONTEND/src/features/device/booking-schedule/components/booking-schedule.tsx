import moment from 'moment';
import { useCallback, useEffect, useState } from 'react';
import { View, Views } from 'react-big-calendar';
import { useParams } from 'react-router-dom';

import { authStore } from '@/lib/auth-store';

import { useSchedulesForDevice, Schedule } from '../api/get-schedules-for-device';

import AddBookingDialog from './add-booking-dialog';
import Calendar from './calendar';
import ScheduleDetailDialog from './schedule-detail-dialog';

import 'react-big-calendar/lib/css/react-big-calendar.css';

const BookingSchedule: React.FC = () => {
  const { deviceId } = useParams<{ deviceId: string }>();
  const { accessData } = authStore.getState();
  const accountId = accessData?.id;
  const [viewDate, setViewDate] = useState(moment()); // Track the current view date
  const [view, setView] = useState<View>(Views.WEEK); // Track the current view (month, week, day)
  const [dateInput, setDateInput] = useState(viewDate.format('YYYY-MM-DD')); // Format the view date for API
  const [selectedSchedule, setSelectedSchedule] = useState<Schedule | null>(null);
  const [isDialogOpen, setIsDialogOpen] = useState(false);

  const {
    data: schedules,
    isLoading,
    isError
  } = useSchedulesForDevice({
    deviceId: deviceId!,
    dateInput,
    timeFrame: view === Views.MONTH ? 'Month' : 'Week'
  });

  useEffect(() => {
    setDateInput(viewDate.format('YYYY-MM-DD')); // Update dateInput whenever viewDate changes
  }, [viewDate]);

  const handleNavigate = (newDate: moment.Moment) => {
    setViewDate(newDate); // Update view date and trigger re-fetch
  };

  const handleViewChange = (newView: View) => {
    setView(newView);
    setDateInput(viewDate.format('YYYY-MM-DD')); // Trigger re-fetch on view change
  };

  const handleDoubleClickEvent = useCallback(
    (calEvent: any) => {
      const schedule = schedules?.find(
        (sched) =>
          sched.account.fullName === calEvent.title &&
          moment(sched.startDate).isSame(calEvent.start) &&
          moment(sched.endDate).isSame(calEvent.end)
      );
      if (schedule) {
        setSelectedSchedule(schedule);
        setIsDialogOpen(true);
      }
    },
    [schedules]
  );

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error loading schedules</div>;
  }

  const events =
    schedules?.map((schedule) => ({
      start: moment(schedule.startDate).toDate(),
      end: moment(schedule.endDate).toDate(),
      title: schedule.account.fullName,
      data: {
        purpose: schedule.purpose,
        phoneNumber: schedule.account.phoneNumber,
        email: schedule.account.email,
        fullName: schedule.account.fullName
      }
    })) || [];

  const EventComponent = ({ event }: { event: any }) => {
    return (
      <div>
        <h3>Borrowed By: {event.title}</h3>
        <h3>Purpose: {event.data?.purpose}</h3>
        <h3>Phone Number: {event.data?.phoneNumber}</h3>
      </div>
    );
  };

  return (
    <div style={{ height: '95vh' }}>
      <div>Device Id: {deviceId}</div>
      <AddBookingDialog deviceId={deviceId!} accountId={accountId} />
      <Calendar
        events={events}
        views={['day', 'week', 'month']}
        view={view}
        onView={handleViewChange}
        components={{ event: EventComponent }}
        date={viewDate.toDate()}
        onNavigate={(newDate) => handleNavigate(moment(newDate))}
        onDoubleClickEvent={handleDoubleClickEvent}
      />
      <ScheduleDetailDialog
        isOpen={isDialogOpen}
        onClose={() => setIsDialogOpen(false)}
        schedule={selectedSchedule}
      />
    </div>
  );
};

export default BookingSchedule;
