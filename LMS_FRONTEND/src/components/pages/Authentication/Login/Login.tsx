import React, { useState } from "react";
import { Link } from "react-router-dom";
import "./login.css";

const Login: React.FC = () => {
  //   const [emailOrRoll, setEmailOrRoll] = useState<string>("");
  //   const [password, setPassword] = useState<string>("");
  //   const [rememberMe, setRememberMe] = useState<boolean>(false);

  //   const handleLogin = (e: React.FormEvent) => {
  //     e.preventDefault();
  //     // Add login logic here
  //     console.log("Login", { emailOrRoll, password, rememberMe });
  //   };

  return (
    <div className="login-container">
      <h1>Student/Supervisor Login</h1>
      {/* <form onSubmit={handleLogin}> */}
      <div className="input-group">
        <input
          type="text"
          placeholder="Roll number or email"
          // value={emailOrRoll}
          // onChange={(e) => setEmailOrRoll(e.target.value)}
          required
        />
      </div>
      <div className="input-group">
        <input
          type="password"
          placeholder="Password"
          // value={password}
          // onChange={(e) => setPassword(e.target.value)}
          required
        />
      </div>
      <div className="actions">
        <label>
          <input
            type="checkbox"
            //   checked={rememberMe}
            //   onChange={(e) => setRememberMe(e.target.checked)}
          />
          Remember me
        </label>
        <a href="#forgot-password">Forgot Password?</a>
      </div>
      <button type="submit">Login</button>
      {/* </form> */}
      <h3>
        Not a member?{" "}
        <Link className="link" to={"/StudentRegister"}>
          Register now
        </Link>
      </h3>
    </div>
  );
};

export default Login;
