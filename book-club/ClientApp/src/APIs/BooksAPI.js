import { useContext, useState, useEffect } from 'react';
import { AppContext } from '../context/GlobalState';
import axios from "axios";


const bookApiUrl = "https://www.googleapis.com/books/v1/volumes/"

//reusable hit to any endpoint
const useAxios = (endpoint) => {
    const [data, setData] = useState([])
    const [loading, setLoading] = useState(false)
    const [error, setError] = useState(null)

    const getData = () => {
        setLoading(true)
        axios
            .get(endpoint)
            .then((response) => {
                setData(response.data)
                setLoading(false)
            })
            .catch((error) => {
                setError(error)
                setLoading(false)
            })
    }

    return {data, loading, error, getData}
}

//hits the Google API to retrieve a book. Retool this when we have DB support for, just has a fixed ID for now (bookId for Dune)
const useGetBook = (bookId) => {
    const fullUrl = bookApiUrl+bookId
    const { setBookTitle, setBookAuthor } = useContext(AppContext)
    const { data, loading, error, getData } = useAxios(fullUrl)

    useEffect(() => {
            if (loading) {
        console.log("Loading...")
    }
    })

    useEffect(() =>{
            if (error) {
        console.log(error.message)
    }
    })

    //make API request
    useEffect(() => {
        getData()
    }, [])

    //prevent until data returned, then update context
    if (!loading && !error && data.volumeInfo){
        setBookTitle(data.volumeInfo.title)
        //authors come back in an array, snag the first result
        setBookAuthor(data.volumeInfo.authors[0])
    }
}

    export default useGetBook