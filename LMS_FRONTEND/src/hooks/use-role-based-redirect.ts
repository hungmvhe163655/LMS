import { useNavigate, useSearchParams } from 'react-router-dom';

import { User } from '@/types/api';

const useRoleBasedRedirect = (user: User) => {
  const navigate = useNavigate();
  const [searchParams] = useSearchParams();
  const redirectTo = searchParams.get('redirectTo');

  const redirectBasedOnRoles = () => {
    if (user.isBanned) {
      navigate('error/ban');
    } else if (user.isDeleted) {
      navigate('error/deleted');
    } else if (redirectTo) {
      navigate(redirectTo, { replace: true });
    } else if (user.roles.includes('Supervisor')) {
      navigate('/dashboard/supervisor');
    } else if (user.roles.includes('Student')) {
      navigate('/dashboard/student');
    } else if (user.roles.includes('LabDirector')) {
      navigate('/dashboard/lab-director');
    }
  };

  return { redirectBasedOnRoles };
};

export default useRoleBasedRedirect;
