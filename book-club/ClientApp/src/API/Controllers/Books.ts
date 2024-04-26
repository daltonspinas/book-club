import {api} from '../googleAxiosConfig'

export const booksAPI = {

    getBook: async function(bookID) {
        const response = await api.request({
            url: `/volumes/${bookID}`,
            method: 'GET',
        })
        return response.data
    }
}