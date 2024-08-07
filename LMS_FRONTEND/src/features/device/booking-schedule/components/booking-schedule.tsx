import moment from 'moment';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import { useSchedulesForDevice } from '../api/get-schedules-for-device';

import Calendar from './calendar';

import 'react-big-calendar/lib/css/react-big-calendar.css';

const BookingSchedule: React.FC = () => {
  const { deviceId } = useParams<{ deviceId: string }>();
  const [viewDate, setViewDate] = useState(moment('2024-07-24')); // Track the current view date
  const [dateInput, setDateInput] = useState(viewDate.format('YYYY-MM-DD')); // Format the view date for API
  const {
    data: schedules,
    isLoading,
    isError
  } = useSchedulesForDevice({ deviceId: deviceId!, dateInput });

  useEffect(() => {
    setDateInput(viewDate.format('YYYY-MM-DD')); // Update dateInput whenever viewDate changes
  }, [viewDate]);

  const handleNavigate = (newDate: moment.Moment) => {
    setViewDate(newDate); // Update view date and trigger re-fetch
  };

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
        <h3>Email: {event.data?.email}</h3>
      </div>
    );
  };

  return (
    <div style={{ height: '95vh' }}>
      <div>Device Id: {deviceId}</div>
      <Calendar
        events={events}
        views={['week', 'day', 'month']}
        components={{ event: EventComponent }}
        date={viewDate.toDate()}
        onNavigate={(newDate) => handleNavigate(moment(newDate))}
      />
    </div>
  );
};

export default BookingSchedule;
