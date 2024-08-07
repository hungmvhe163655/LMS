import moment from 'moment';
import { useParams } from 'react-router-dom';

import Calendar from './calendar';

import 'react-big-calendar/lib/css/react-big-calendar.css';
const BookingSchedule: React.FC = () => {
  const { deviceId } = useParams<{ deviceId: string }>();
  const events = [
    {
      start: moment('2024-08-06T10:00:00').toDate(),
      end: moment('2024-08-06T12:00:00').toDate(),
      title: 'Dev HungMV'
    },
    {
      start: moment('2024-08-06T14:00:00').toDate(),
      end: moment('2024-08-06T18:00:00').toDate(),
      title: 'Thang Hung gay'
    },
    {
      start: moment('2024-08-06T20:30:00').toDate(),
      end: moment('2024-08-06T21:30:00').toDate(),
      title: 'Meo meo'
    }
  ];

  // const components = {
  //   event: (props: any) => {
  //     console.log('prprop', props);
  //     return null;
  //   }
  // };

  return (
    <div style={{ height: '95vh' }}>
      <div>Device Id: {deviceId}</div>
      <Calendar events={events} views={['week', 'day', 'month']}></Calendar>
    </div>
  );
};
export default BookingSchedule;
