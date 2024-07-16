import PasswordRoute from './password';
import PhoneNumberRoute from './phone-number';

const ProfileRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { OverallPage: Overall } = await import('./overall/overall-page');
        return { Component: Overall };
      }
    },
    PasswordRoute,
    PhoneNumberRoute
  ]
};

export default ProfileRoute;
