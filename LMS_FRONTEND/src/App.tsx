import React from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Login from "./components/pages/Authentication/Login/Login";
import StudentRegister from "./components/pages/Authentication/StudentRegister/StudentRegister";
import SupervisorRegisterForm from "./components/pages/Authentication/SupervisorRegister/SupervisorRegister";
import Register from "./components/pages/Authentication/ChooseRole/ChooseRole";
import ForgotPassword from "./components/pages/Authentication/ForgotPassword/ForgotPassword";
import ValidateRollNumber from "./components/pages/Authentication/ValidateStudentRollNumber/ValidateStudentRollNumber";
import ValidateEmail from "./components/pages/Authentication/ValidateEmail/ValidateEmail";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Login />,
    errorElement: <div>Error 404 Not Found</div>,
  },
  {
    path: "/Register",
    element: <Register />,
  },
  {
    path: "/StudentRegister",
    element: <StudentRegister />,
  },
  {
    path: "/SupervisorRegister",
    element: <SupervisorRegisterForm />,
  },
  {
    path: "/ForgotPassword",
    element: <ForgotPassword />,
  },
  {
    path: "/ValidateRollNumber",
    element: <ValidateRollNumber />,
  },
  {
    path: "/ValidateEmail",
    element: <ValidateEmail />,
  },
]);

const App: React.FC = () => {
  return (
    <div className="App">
      <RouterProvider router={router} />
    </div>
  );
};

export default App;
