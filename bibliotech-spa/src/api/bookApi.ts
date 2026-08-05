import axios from "axios";

const API_URL = "http://localhost:5013/api/books";

export const bookApi = {
  getAll: async () => {
    const response = await axios.get(API_URL);
    return response.data;
  },

  getById: async (id: number) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  },

  create: async (book: any) => {
    const response = await axios.post(API_URL, book);
    return response.data;
  }
};
