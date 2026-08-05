import axios from "axios";

const API_URL = "http://localhost:5013/api/loans";

export const loanApi = {
  borrow: async (memberId: number, bookId: number) => {
    const response = await axios.post(`${API_URL}?memberId=${memberId}&bookId=${bookId}`);
    return response.data;
  },

  returnLoan: async (loanId: number) => {
    const response = await axios.post(`${API_URL}/${loanId}/return`);
    return response.data;
  }
};

