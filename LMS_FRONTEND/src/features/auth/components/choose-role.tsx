import { Link } from 'react-router-dom';

function ChooseRoleRegister() {
  return (
    <div className='register-container'>
      <div className='button-container'>
        <Link to='/auth/validate-roll-number'>
          <img
            src='src\assets\Supervisor Button.png'
            alt='Supervisor Register'
            className='register-button'
          />
        </Link>
        <Link to='/register/student'>
          <img
            src='src\assets\Student Button.png'
            alt='Student Register'
            className='register-button'
          />
        </Link>
      </div>
    </div>
  );
}

export default ChooseRoleRegister;
