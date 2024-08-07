const BookingScheduleRoute = {
  path: 'booking/:deviceId',
  lazy: async () => {
    const { BookingSchedulePage: BookingSchedulePage } = await import('./booking-schedule-page');
    return { Component: BookingSchedulePage };
  }
};

export default BookingScheduleRoute;
