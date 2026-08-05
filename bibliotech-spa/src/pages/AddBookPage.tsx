import { useState } from "react";
import { bookApi } from "../api/bookApi";

export default function AddBookPage() {
  const [titre, setTitre] = useState("");
  const [auteur, setAuteur] = useState("");
  const [total, setTotal] = useState(1);

  const submit = async () => {
    const book = {
      titre,
      auteur,
      nombreExemplairesTotal: total,
      nombreExemplairesDisponibles: total
    };

    try {
      await bookApi.create(book);
      alert("Livre ajouté au catalogue !");
      setTitre("");
      setAuteur("");
      setTotal(1);
    } catch (err: any) {
      const message = err.response?.data?.error || "Erreur lors de l'ajout";
      alert(message);
    }
  };

  return (
    <div>
      <h2>Enregistrer un livre au catalogue</h2>

      <label>
        Titre :
        <input value={titre} onChange={(e) => setTitre(e.target.value)} />
      </label>

      <br />

      <label>
        Auteur :
        <input value={auteur} onChange={(e) => setAuteur(e.target.value)} />
      </label>

      <br />

      <label>
        Nombre d'exemplaires :
        <input
          type="number"
          value={total}
          onChange={(e) => setTotal(Number(e.target.value))}
        />
      </label>

      <br />

      <button onClick={submit}>Enregistrer</button>
    </div>
  );
}
