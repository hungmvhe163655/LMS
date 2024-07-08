import ForgotPasswordRoute from './forget-password';
import LoginRoute from './login';
import RegisterRoute from './register';

const AuthRoute = {
  children: [RegisterRoute, LoginRoute, ForgotPasswordRoute]
};

export default AuthRoute;
