import {api} from '../axiosConfig'

// TODO: find a place for interfaces once upgraded to Typescript

// interface LoginDTO {
//     Email: string,
//     Password: string
// }

const controllerBase = '/user'

// TODO: Find a tool we can use to automap controller methods/params from the .NET side
export const userAPI = {

    login: async function(loginInfo) {
        const response = await api.request({
            url: `${controllerBase}/login`,
            method: 'POST',
            data: loginInfo
        })
        return response.data
    },

    signUp: async function(signUpInfo) {
        const response = await api.request({
            url: `${controllerBase}/create-user`,
            method: 'POST',
            data: signUpInfo
        })
        return response.data
    },

    getAll: async function() {
        const response = await api.request({
            url: `${controllerBase}/get-all`,
            method: 'GET',
        })
        return response.data
    }
}