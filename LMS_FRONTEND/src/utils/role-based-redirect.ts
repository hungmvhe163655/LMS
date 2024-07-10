import { Roles } from '@/types/api';

const getRedirectBasedOnRoles = (roles: Roles): string => {
  if (roles.includes('Supervisor')) {
    return '/dashboard/supervisor';
  } else if (roles.includes('Student')) {
    return '/dashboard/student';
  } else if (roles.includes('LabDirector')) {
    return '/dashboard/lab-director';
  } else {
    return '/';
  }
};

export default getRedirectBasedOnRoles;
