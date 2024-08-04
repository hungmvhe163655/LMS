import { Roles } from '@/types/api';
import { ROLES } from '@/types/constant';

const getRedirectBasedOnRoles = (roles: Roles): string => {
  if (roles.includes(ROLES.SUPERVISOR)) {
    return '/dashboard/supervisor';
  } else if (roles.includes(ROLES.STUDENT)) {
    return '/dashboard/student';
  } else if (roles.includes(ROLES.LAB_ADMIN)) {
    return '/dashboard/lab-director';
  } else {
    return '/';
  }
};

export default getRedirectBasedOnRoles;
