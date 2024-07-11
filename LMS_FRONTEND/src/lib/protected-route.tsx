import useIsAuthenticated from 'react-auth-kit/hooks/useIsAuthenticated';
import { useLocation, Navigate } from 'react-router-dom';

import { toast } from '@/components/ui/use-toast';

export const ProtectedRoute = ({ children }: { children: React.ReactNode }) => {
  const isAuthenticated = useIsAuthenticated();
  const location = useLocation();

  if (!isAuthenticated) {
    toast({
      variant: 'destructive',
      description: 'You must login first!'
    });

    return (
      <Navigate to={`/auth/login?redirectTo=${encodeURIComponent(location.pathname)}`} replace />
    );
  }

  return children;
};
