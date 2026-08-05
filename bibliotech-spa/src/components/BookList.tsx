export default function BookList({ books, onBorrow }: any) {
  return (
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
        {books.map((b: any) => (
          <tr key={b.id}>
            <td>{b.titre}</td>
            <td>{b.auteur}</td>
            <td>{b.nombreExemplairesDisponibles}</td>
            <td>
              <button onClick={() => onBorrow(b.id)}>Emprunter</button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}