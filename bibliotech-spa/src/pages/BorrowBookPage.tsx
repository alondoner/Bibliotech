import { useEffect, useState } from "react";
import { bookApi } from "../api/bookApi";
import { loanApi } from "../api/loanApi";

export default function BorrowBookPage() {
  const [books, setBooks] = useState<any[]>([]);
  const [memberId, setMemberId] = useState<number>(1);

  useEffect(() => {
    bookApi.getAll().then(setBooks);
  }, []);

  const borrow = async (bookId: number) => {
    try {
      await loanApi.borrow(memberId, bookId);
      alert("Emprunt effectué !");
    } catch (err: any) {
      alert(err.response?.data?.error || "Erreur lors de l'emprunt");
    }
  };

  return (
    <div>
      <h2>Emprunter un livre</h2>

      <label>
        ID Adhérent :
        <input
          type="number"
          value={memberId}
          onChange={(e) => setMemberId(Number(e.target.value))}
        />
      </label>

      <table>
        <thead>
          <tr>
            <th>Titre</th>
            <th>Auteur</th>
            <th>Disponibles</th>
            <th></th>
          </tr>
        </thead>

        <tbody>
          {books.map((b) => (
            <tr key={b.id}>
              <td>{b.titre}</td>
              <td>{b.auteur}</td>
              <td>{b.nombreExemplairesDisponibles}</td>
              <td>
                <button onClick={() => borrow(b.id)}>Emprunter</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
