import { LoginDTO, SignUpDTO } from '../../interfaces/DTOs'
import {api} from '../axiosConfig'

// TODO: find a place for interfaces once upgraded to Typescript

const controllerBase = '/user'

// TODO: Find a tool we can use to automap controller methods/params from the .NET side
export const userAPI = {

    login: async function(loginInfo: LoginDTO) {
        
        const response = await api.request({
            url: `${controllerBase}/login`,
            method: 'POST',
            data: loginInfo
        })
        return response.data
    },

    logout: async function() {
        const response = await api.request({
            url: `${controllerBase}/logout`,
            method: 'POST'
        })
        return response.data
    }, 

    signUp: async function(signUpInfo: SignUpDTO) {
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
    },

    getAppUserInfo: async function() {
        const response = await api.request({
            url: `${controllerBase}/user-info`,
            method: 'GET',
        })
        return response.data
    }
}