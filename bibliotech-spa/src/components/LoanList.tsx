export default function LoanList({ loans, onReturn }: any) {
  return (
    <ul>
      {loans.map((l: any) => (
        <li key={l.id}>
          {l.book.titre} — Échéance : {new Date(l.dateEcheance).toLocaleDateString()}
          {l.dateRetour ? (
            <span> (retourné)</span>
          ) : (
            <button onClick={() => onReturn(l.id)}>Retourner</button>
          )}
        </li>
      ))}
    </ul>
  );
}



