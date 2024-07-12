import useIsAuthenticated from 'react-auth-kit/hooks/useIsAuthenticated';
import { useLocation, Navigate } from 'react-router-dom';

import { useToast } from '@/components/ui/use-toast';

export const ProtectedRoute = ({ children }: { children: React.ReactNode }) => {
  const isAuthenticated = useIsAuthenticated();
  const location = useLocation();
  const { toast } = useToast();

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
