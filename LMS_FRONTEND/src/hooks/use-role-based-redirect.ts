import { useState } from 'react';

import { User } from '@/types/api';

const useRoleBasedRedirect = (initialUser: User | null) => {
  const [user, setUser] = useState<User | null>(initialUser);

  const getRedirectBasedOnRoles = (): string => {
    if (!user) return '/';
    if (user.isBanned) {
      return 'auth/ban';
    } else if (user.isDeleted) {
      return 'auth/deleted';
    } else if (!user.isVerified) {
      return 'auth/verified';
    } else if (user.roles.includes('Supervisor')) {
      return '/dashboard/supervisor';
    } else if (user.roles.includes('Student')) {
      return '/dashboard/student';
    } else if (user.roles.includes('LabDirector')) {
      return '/dashboard/lab-director';
    } else {
      return '/';
    }
  };

  return { setUser, getRedirectBasedOnRoles };
};

export default useRoleBasedRedirect;
