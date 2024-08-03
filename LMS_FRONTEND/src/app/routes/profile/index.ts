import EmailRoute from './email';
import PasswordRoute from './password';
import PhoneNumberRoute from './phone-number';
import TwoFactorRoute from './two-factor';

const ProfileRoute = {
  children: [
    {
      index: true,
      lazy: async () => {
        const { OverallPage: Overall } = await import('./overall/overall-page');
        return { Component: Overall };
      }
    },
    EmailRoute,
    PasswordRoute,
    PhoneNumberRoute,
    TwoFactorRoute
  ]
};

export default ProfileRoute;
