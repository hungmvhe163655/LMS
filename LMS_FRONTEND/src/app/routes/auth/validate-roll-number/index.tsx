const ValidateRollNumberRoute = {
  path: 'roll-number',
  lazy: async () => {
    const { ValidateRollNumberPage: ValidateRollNumberPage } = await import(
      './validate-student-roll-number-page'
    );
    return { Component: ValidateRollNumberPage };
  }
};

export default ValidateRollNumberRoute;
