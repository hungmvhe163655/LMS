const StudentRegisterRoute = {
  path: 'student',
  lazy: async () => {
    const { StudentRegisterPage: StudentRegisterPage } = await import('./register-page');
    return { Component: StudentRegisterPage };
  }
};

export default StudentRegisterRoute;
