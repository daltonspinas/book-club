import React, { useContext, useEffect, useState } from "react";
import { userAPI } from "../API/Controllers/User";
import { useNavigate } from "react-router-dom";
import { AppUserContext } from "../context/UserContext";
import { LoginDTO, SignUpDTO } from "../interfaces/DTOs";

export function LoginSignup() {
  //state hooks for login path
  const [loginData, setLoginData] = useState<LoginDTO>({ email: "", password: "" });

  const [isLoggedIn, setIsLoggedIn] = useState(
    localStorage.getItem("accessToken") ? true : false
  );
  
  //state hooks for create acct path
  const [createData, setCreateData] = useState({
    username: "",
    email: "",
    password1: "",
    password2: "",
  });

  const { appUser, setAppUser } = useContext(AppUserContext);

  const navigate = useNavigate();

  useEffect(() => {
    if (isLoggedIn) navigate("/");
  }, [isLoggedIn]);

  const handleLoginChange = (event: React.FormEvent<HTMLInputElement>) => {
    const { name, value } = event.currentTarget;
    setLoginData((previousData) => ({ ...previousData, [name]: value }));
  };

  const handleLoginSubmit = async (event: React.FormEvent) => {
    event.preventDefault();

    userAPI.login(loginData).then((data) => {
      localStorage.setItem("accessToken", data);
      userAPI.getAppUserInfo().then((userInfo) => {
        setAppUser(userInfo);
        setIsLoggedIn(true);
      });
    });
  };


  const handleCreateChange = (event: React.FormEvent<HTMLInputElement>) => {
    const { name, value } = event.currentTarget;
    setCreateData((previousData) => ({ ...previousData, [name]: value }));
  };

  const handleCreateSubmit = async (event: React.FormEvent<any>) => {
    event.preventDefault();
    // check for matching passwords
    if (event.currentTarget.password1.value !== event.currentTarget.password2.value) {
      alert("Passwords do not match, please try again");
    }

    // TODO: Upgrade to Typescript
    const userDTO: SignUpDTO = {
      username: createData.username,
      email: createData.email,
      password: createData.password1,
    };

    userAPI.signUp(userDTO).then((data) => console.log(data));
  };

  const handleLogout = async () => {
    userAPI.logout().then((data) => {
      localStorage.removeItem("accessToken");
      setIsLoggedIn(false);
    });
  };

  if (isLoggedIn) {
    return <button onClick={handleLogout}>Logout</button>;
  } else {
    return (
      <div className="h-screen grid items-center justify-center">
        <h1 className="justify-self-center">Please Login</h1>
        <form onSubmit={handleLoginSubmit} className="justify-self-center">
          <label>
            Email:
            <input
              type="email"
              name="email"
              value={loginData.email}
              onChange={handleLoginChange}
            />
          </label>
          <label>
            Password:
            <input
              type="password"
              name="password"
              value={loginData.password}
              onChange={handleLoginChange}
            />
          </label>
          <input type="submit" value="Submit" />
        </form>
        <h1 className="justify-self-center">Or Create Account</h1>
        <form onSubmit={handleCreateSubmit} className="justify-self-center">
          <div className="justify-self-center">
            <label>
              Name:
              <input
                type="text"
                name="userName"
                value={createData.username}
                onChange={handleCreateChange}
              />
            </label>
            <label>
              Email:
              <input
                type="email"
                name="email"
                value={createData.email}
                onChange={handleCreateChange}
              />
            </label>
          </div>
          <div className="justify-self-center">
            <label>
              Password:
              <input
                type="password"
                name="password1"
                value={createData.password1}
                onChange={handleCreateChange}
              />
            </label>
            <label>
              Confirm Password:
              <input
                type="password"
                name="password2"
                value={createData.password2}
                onChange={handleCreateChange}
              />
            </label>
          </div>
          <input type="submit" value="Submit" />
        </form>
      </div>
    );
  }
}
