import React, { useContext, useState, useEffect } from 'react';
import axios from "axios";


const bookApiUrl = "https://www.googleapis.com/books/v1/volumes/"
const bookId = "OXzLsgEACAAJ?key=AIzaSyB8Qt63pYxZHRNxlDJQQUYQLS4Zuqcw5ZU"

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

const useGetBook = () => {
    const fullUrl = bookApiUrl+bookId
    const { data, loading, error, getData } = useAxios(fullUrl)

    if (loading) {
        return <p>Loading...</p>
    }

    if (error) {
        console.log(error.message)
        return <p>Error!</p>
    }

    getData()
    console.log(data)

    return (
        //make this update the context
       data
    )
}

    export default useGetBook