import { useCallback, useEffect, useState } from "react";
import { memberApi } from "../api/memberApi";
import { loanApi } from "../api/loanApi";

export default function MemberLoansPage() {
    const [memberId, setMemberId] = useState<number>(1);
    const [loans, setLoans] = useState<any[]>([]);

    const loadLoans = useCallback(async () => {
        const data = await memberApi.getLoans(memberId);
        setLoans(data);
    }, [memberId]);

    useEffect(() => {
        loadLoans();
    }, [loadLoans]);

    const returnLoan = async (loanId: number) => {
        await loanApi.returnLoan(loanId);
        await loadLoans();
    };

    return (
        <div>
            <h2>Emprunts par adhérent</h2>

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
                        {l.book.titre} — Échéance : {new Date(l.dateEcheance).toLocaleDateString()}
                        {l.dateRetour ? (
                            <span> (retourné)</span>
                        ) : (
                            <button onClick={() => returnLoan(l.id)}>Retourner</button>
                        )}
                    </li>
                ))}
            </ul>
        </div>
    );
}


