import { useEffect, useState } from "react";
import { memberApi } from "../api/memberApi";
import { loanApi } from "../api/loanApi";

export default function ReturnBookPage() {
  const [memberId, setMemberId] = useState<number>(1);
  const [loans, setLoans] = useState<any[]>([]);

  const loadLoans = () => {
    memberApi.getLoans(memberId).then(setLoans);
  };

  useEffect(() => {
    loadLoans();
  }, [memberId]);

  const returnLoan = async (loanId: number) => {
    await loanApi.returnLoan(loanId);
    alert("Livre retourné !");
    loadLoans();
  };

  return (
    <div>
      <h2>Retour d'un livre</h2>

      <label>
        ID Adhérent :
        <input
          type="number"
          value={memberId}
          onChange={(e) => setMemberId(Number(e.target.value))}
        />
      </label>

      <ul>
        {loans.map((l) => (
          <li key={l.id}>
            {l.book.titre} — Échéance :{" "}
            {new Date(l.dateEcheance).toLocaleDateString()}
            {l.dateRetour ? (
              <span> (déjà retourné)</span>
            ) : (
              <button onClick={() => returnLoan(l.id)}>Retourner</button>
            )}
          </li>
        ))}
      </ul>
    </div>
  );
}
