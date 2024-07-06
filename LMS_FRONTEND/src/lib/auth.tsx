import useIsAuthenticated from 'react-auth-kit/hooks/useIsAuthenticated';
import { useLocation, Navigate } from 'react-router-dom';

export const ProtectedRoute = ({ children }: { children: React.ReactNode }) => {
  const isAuthenticated = useIsAuthenticated();
  const location = useLocation();

  if (!isAuthenticated) {
    return (
      <Navigate to={`/auth/login?redirectTo=${encodeURIComponent(location.pathname)}`} replace />
    );
  }

  return children;
};
