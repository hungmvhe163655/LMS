const BookingScheduleRoute = {
  path: 'booking',
  lazy: async () => {
    const { BookingSchedulePage: BookingSchedulePage } = await import('./booking-schedule-page');
    return { Component: BookingSchedulePage };
  }
};

export default BookingScheduleRoute;
