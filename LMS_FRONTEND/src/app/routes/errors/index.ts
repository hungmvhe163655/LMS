import BannedAccountRoute from './ban-account';
import NotAuthorizedRoute from './not-authorized';

const ErrorRoute = {
  children: [BannedAccountRoute, NotAuthorizedRoute]
};

export default ErrorRoute;
