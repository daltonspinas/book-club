import {api} from '../googleAxiosConfig'

export const booksAPI = {

    getBook: async function(bookID: string) {
        const response = await api.request({
            url: `/volumes/${bookID}`,
            method: 'GET',
        })
        return response.data
    }
}