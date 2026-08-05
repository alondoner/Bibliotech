import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import AddBookPage from "./pages/AddBookPage";
import BorrowBookPage from "./pages/BorrowBookPage";
import ReturnBookPage from "./pages/ReturnBookPage";
import MemberPenaltiesPage from "./pages/MemberPenaltiesPage";

export default function App() {
    return (
        <BrowserRouter>
            <nav>
                <Link to="/">Enregistrer un livre</Link> |{" "}
                <Link to="/borrow">Emprunter un livre</Link> |{" "}
                <Link to="/return">Retourner un livre</Link> |{" "}
                <Link to="/penalties">P&eacute;nalit&eacute;s par adh&eacute;rent</Link>
            </nav>

            <Routes>
                <Route path="/" element={<AddBookPage />} />
                <Route path="/borrow" element={<BorrowBookPage />} />
                <Route path="/return" element={<ReturnBookPage />} />
                <Route path="/penalties" element={<MemberPenaltiesPage />} />
            </Routes>
        </BrowserRouter>
    );
}
