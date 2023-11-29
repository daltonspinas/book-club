import React, {Component, useState, useContext} from "react";

export function LoginSignup() {


    //state hooks for login path
    const [loginData, setLoginData] = useState({email:"", password:""})

    const handleLoginChange = (event) => {
        const {name, value} = event.target
        setLoginData((previousData) => ({...previousData, [name]: value}))
    }

    const handleLoginSubmit = (event) =>{
        event.preventDefault()
        //TODO: replace this log with something useful
        console.log(loginData)
    }

    //state hooks for create acct path
    const [createData, setCreateData] = useState({userName:"", email:"", password1:"", password2:""})

    const handleCreateChange = (event) => {
        const {name, value} = event.target
        setCreateData((previousData) => ({...previousData, [name]: value}))
    }

    const handleCreateSubmit = (event) => {
        event.preventDefault()
        //TODO: replace this with something useful
        console.log(createData)
    }

    return(
        <div>
            <h1>Please Login</h1>
            <form onSubmit={handleLoginSubmit}>
                <label>
                    Email:
                    <input type="text" name="email" value={loginData.email} onChange={handleLoginChange}/>
                </label>
                <label>
                    Password:
                    <input type="text" name="password" value={loginData.password} onChange={handleLoginChange}/>
                </label>
                <input type="submit" value="Submit"/>
            </form>
            <h1>Or Create Account</h1>
            <form onSubmit={handleCreateSubmit}>
                <label>
                    Name:
                    <input type="text" name="userName" value={createData.userName} onChange={handleCreateChange}/>
                </label>
                <label>
                    Email:
                    <input type="email" name="email" value={createData.email} onChange={handleCreateChange}/>
                </label>
                <label>
                    Password:
                    <input type="password" name="password1" value={createData.password1} onChange={handleCreateChange}/>
                </label>
                <label>
                    Confirm Password:
                    <input type="password" name="password2" value={createData.password2} onChange={handleCreateChange}/>
                </label>
                <input type="submit" value="Submit"/>
            </form>
        </div>
    )
}