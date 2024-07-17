import { useEffect } from 'react';
import { useLocation, Navigate } from 'react-router-dom';

import { toast } from '@/components/ui/use-toast';
import { Roles } from '@/types/api';

import { authStore } from './auth-store';

type ProtectedRouteProps = {
  children: React.ReactNode;
  roles?: Roles;
};

export const ProtectedRoute = ({ children, roles }: ProtectedRouteProps) => {
  const { accessData } = authStore.getState();
  const location = useLocation();

  useEffect(() => {
    if (!accessData) {
      toast({
        variant: 'destructive',
        description: 'You must login first!'
      });
    }
  }, [accessData]);

  if (!accessData) {
    return (
      <Navigate to={`/auth/login?redirectTo=${encodeURIComponent(location.pathname)}`} replace />
    );
  }

  if (roles) {
    const hasRequiredRole = roles.some((role) => accessData.roles.includes(role));
    if (!hasRequiredRole) return <Navigate to={'/errors/not-authorized'} />;
  }

  return children;
};
