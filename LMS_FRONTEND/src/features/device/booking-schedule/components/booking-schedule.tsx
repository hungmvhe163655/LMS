import moment from 'moment';
import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';

import { useSchedulesForDevice } from '../api/get-schedules-for-device';

import Calendar from './calendar';

import 'react-big-calendar/lib/css/react-big-calendar.css';

const BookingSchedule: React.FC = () => {
  const { deviceId } = useParams<{ deviceId: string }>();
  // const [dateInput, setDateInput] = useState(moment().format('YYYY-MM-DD'));
  const [dateInput] = useState(moment().format('YYYY-MM-DD'));
  const {
    data: schedules,
    isLoading,
    isError
  } = useSchedulesForDevice({ deviceId: deviceId!, dateInput });

  useEffect(() => {
    if (!deviceId) {
      // Handle error if deviceId is missing
    }
  }, [deviceId]);

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
      />
    </div>
  );
};

export default BookingSchedule;
