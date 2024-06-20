import StudentRegisterRoute from './student';
import SupervisorRegisterRoute from './supervisor';

const ChooseRoleRoute = {
  path: 'choose-role',
  children: [StudentRegisterRoute, SupervisorRegisterRoute],
  lazy: async () => {
    const { ChooseRolePage: ChooseRolePage } = await import('./choose-role-page');
    return { Component: ChooseRolePage };
  }
};

export default ChooseRoleRoute;
