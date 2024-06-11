import React, { useState } from "react";
import "./StudentRegister.css";

const StudentRegister: React.FC = () => {
  // const [fullName, setFullName] = useState<string>("");
  // const [email, setEmail] = useState<string>("");
  // const [phoneNumber, setPhoneNumber] = useState<string>("");
  // const [supervisor, setSupervisor] = useState<string>("");
  // const [password, setPassword] = useState<string>("");
  // const [reEnterPassword, setReEnterPassword] = useState<string>("");
  // const [agreed, setAgreed] = useState<boolean>(false);

  // const handleRegister = (e: React.FormEvent) => {
  //   e.preventDefault();
  //   // Add registration logic here
  //   console.log("Register", {
  //     fullName,
  //     email,
  //     phoneNumber,
  //     supervisor,
  //     password,
  //     reEnterPassword,
  //     agreed,
  //   });
  // };

  return (
    <div className="register-container">
      <h1>Student Register</h1>
      {/* <form onSubmit={handleRegister}> */}
      <div className="input-group">
        <input
          type="text"
          placeholder="Fullname"
          // value={fullName}
          // onChange={(e) => setFullName(e.target.value)}
          required
        />
      </div>
      <div className="input-group">
        <input
          type="email"
          placeholder="Email"
          // value={email}
          // onChange={(e) => setEmail(e.target.value)}
          required
        />
      </div>
      <div className="input-group">
        <input
          type="tel"
          placeholder="Phone Number"
          // value={phoneNumber}
          // onChange={(e) => setPhoneNumber(e.target.value)}
          required
        />
      </div>
      <div className="input-group">
        <input
          type="text"
          placeholder="Select Supervisor"
          // value={supervisor}
          // onChange={(e) => setSupervisor(e.target.value)}
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
      <div className="input-group">
        <input
          type="password"
          placeholder="Re-enter Password"
          // value={reEnterPassword}
          // onChange={(e) => setReEnterPassword(e.target.value)}
          required
        />
      </div>
      <div className="actions">
        <label>
          <input
            type="checkbox"
            // checked={agreed}
            // onChange={(e) => setAgreed(e.target.checked)}
            required
          />
          I have read and agree with the{" "}
          <a href="#regulations">Regulations Of Laboratory</a>
        </label>
      </div>
      <button type="submit">Register</button>
      {/* </form> */}
    </div>
  );
};

export default StudentRegister;
