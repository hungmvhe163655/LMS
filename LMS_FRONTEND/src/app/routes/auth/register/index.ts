import ChooseRoleRoute from './choose-role';

const RegisterRoute = {
  path: 'register',
  children: [ChooseRoleRoute]
};

export default RegisterRoute;
