const PhoneNumberRoute = {
  path: 'phone-number',
  lazy: async () => {
    const { PhoneNumber } = await import('./phone-number');
    return { Component: PhoneNumber };
  }
};

export default PhoneNumberRoute;
