const PhoneNumberRoute = {
  path: 'phone-number',
  lazy: async () => {
    const { PhoneNumberPage: PhoneNumberPage } = await import('./phone-number-page');
    return { Component: PhoneNumberPage };
  }
};

export default PhoneNumberRoute;
