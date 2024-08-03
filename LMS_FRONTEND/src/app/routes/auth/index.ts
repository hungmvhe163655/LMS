import ForgotPasswordRoute from './forget-password';
import LoginRoute from './login';
import NotVerifiedRoute from './not-verified';
import RegisterRoute from './register';

const AuthRoute = {
  children: [RegisterRoute, LoginRoute, ForgotPasswordRoute, NotVerifiedRoute]
};

export default AuthRoute;
