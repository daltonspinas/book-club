import axios from "axios"

const client = axios.create({
    baseURL: "https://www.googleapis.com/books/v1/volumes"
})

export async function getBookByID(id){
    await client.get(id).then((response) => {
        console.log(response.data.volumeInfo.title)
        let resultObj = {
            title: response.data.volumeInfo.title,
            author: response.data.volumeInfo.author,
            
        }
        return resultObj;
    })
}

export function searchBooks(searchTerms){

}   