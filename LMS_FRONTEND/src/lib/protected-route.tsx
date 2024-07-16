import { useEffect } from 'react';
import { useLocation, Navigate } from 'react-router-dom';

import { toast } from '@/components/ui/use-toast';
import { Roles } from '@/types/api';

import { useAccessData } from './auth-store';

type ProtectedRouteProps = {
  children: React.ReactNode;
  roles?: Roles;
};

export const ProtectedRoute = ({ children, roles }: ProtectedRouteProps) => {
  const auth = useAccessData();
  const location = useLocation();

  useEffect(() => {
    if (!auth) {
      toast({
        variant: 'destructive',
        description: 'You must login first!'
      });
    }
  }, [auth]);

  if (!auth) {
    return (
      <Navigate to={`/auth/login?redirectTo=${encodeURIComponent(location.pathname)}`} replace />
    );
  }

  if (roles) {
    const hasRequiredRole = roles.some((role) => auth.roles.includes(role));
    if (!hasRequiredRole) return <Navigate to={'/errors/not-authorized'} />;
  }

  return children;
};
