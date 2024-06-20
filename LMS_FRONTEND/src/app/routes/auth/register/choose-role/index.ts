import StudentRegisterRoute from './student';
import SupervisorRegisterRoute from './supervisor';

const ChooseRoleRoute = {
  path: 'choose-role',

  children: [
    {
      index: true,
      lazy: async () => {
        const { ChooseRolePage: ChooseRolePage } = await import('./choose-role-page');
        return { Component: ChooseRolePage };
      }
    },
    StudentRegisterRoute,
    SupervisorRegisterRoute
  ]
};

export default ChooseRoleRoute;
