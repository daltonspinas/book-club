import React, {useState} from "react";

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
        //check for matching passwords
        if (event.target.password1.value !== event.target.password2.value) {
            alert("Passwords do not match, please try again")
        }
        //TODO: replace this with something useful
        console.log(createData)
    }

    return(
        <div className='h-screen grid items-center justify-center'>
            <h1 className='justify-self-center'>Please Login</h1>
            <form onSubmit={handleLoginSubmit} className='justify-self-center'>
                <label>
                    Email:
                    <input type="email" name="email" value={loginData.email} onChange={handleLoginChange}/>
                </label>
                <label>
                    Password:
                    <input type="password" name="password" value={loginData.password} onChange={handleLoginChange}/>
                </label>
                <input type="submit" value="Submit"/>
            </form>
            <h1 className='justify-self-center'>Or Create Account</h1>
            <form onSubmit={handleCreateSubmit} className='justify-self-center'>
                <div className='justify-self-center'>
                <label>
                    Name:
                    <input type="text" name="userName" value={createData.userName} onChange={handleCreateChange}/>
                </label>
                <label>
                    Email:
                    <input type="email" name="email" value={createData.email} onChange={handleCreateChange}/>
                </label>
                </div>
                <div className='justify-self-center'> 
                <label>
                    Password:
                    <input type="password" name="password1" value={createData.password1} onChange={handleCreateChange}/>
                </label>
                <label>
                    Confirm Password:
                    <input type="password" name="password2" value={createData.password2} onChange={handleCreateChange}/>
                </label>
                </div>
                <input type="submit" value="Submit"/>
            </form>
        </div>
    )
}