import React from "react";
import { ReactDOM } from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
// import "./App.css";
import Login from "./components/pages/Authentication/Login/Login";
import StudentRegister from "./components/pages/Authentication/StudentRegister/StudentRegister";
// import { Button } from "@/components/ui/button";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Login />,
    errorElement: <div>Error 404 Not Found</div>,
  },
  {
    path: "/StudentRegister",
    element: <StudentRegister />,
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
