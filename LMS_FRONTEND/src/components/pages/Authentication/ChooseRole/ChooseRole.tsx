import React from "react";
import { Link } from "react-router-dom";
import "./chooseRole.css";

const Register: React.FC = () => {
  return (
    <div className="register-container">
      <div className="button-container">
        <Link to="/SupervisorRegister">
          <img
            src="src\assets\Supervisor Button.png"
            alt="Supervisor Register"
            className="register-button"
          />
        </Link>
        <Link to="/ValidateRollNumber">
          <img
            src="src\assets\Student Button.png"
            alt="Student Register"
            className="register-button"
          />
        </Link>
      </div>
    </div>
  );
};

export default Register;
