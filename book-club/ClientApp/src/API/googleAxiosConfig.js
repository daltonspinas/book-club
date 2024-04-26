import axios from "axios";
import { useEffect } from "react";

export const api = axios.create({
    baseURL: "https://www.googleapis.com/books/v1",
});

// defining a custom error handler for all APIs
const errorHandler = (error) => {
  const statusCode = error.response?.status;
  console.error(statusCode, error);
  return Promise.reject(error);
};

export default function AxiosConfig() {

  // wrap in useEffect so we don't register a new interceptor every time
  useEffect(() => {
    api.interceptors.response.use(undefined, (error) => {
      return errorHandler(error);
    });

    api.interceptors.request.use((config) => {
      return config;
    });
  }, []);
}