import axios from "axios";

const API_URL = "http://localhost:5013/api/members";

export const memberApi = {
  getById: async (id: number) => {
    const response = await axios.get(`${API_URL}/${id}`);
    return response.data;
  },

  create: async (member: any) => {
    const response = await axios.post(API_URL, member);
    return response.data;
  },

  getLoans: async (id: number) => {
    const response = await axios.get(`${API_URL}/${id}/loans`);
    return response.data;
  },

  getPenalties: async (id: number) => {
    const response = await axios.get(`${API_URL}/${id}/penalties`);
    return response.data;
  }
};
