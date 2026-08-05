import { useEffect, useState } from "react";
import { memberApi } from "../api/memberApi";

export default function MemberPenaltiesPage() {
  const [memberId, setMemberId] = useState<number>(1);
  const [penalties, setPenalties] = useState<number>(0);

  useEffect(() => {
    memberApi.getPenalties(memberId).then((data) => {
      setPenalties(data.totalPenalties);
    });
  }, [memberId]);

  return (
    <div>
      <h2>Pénalités par adhérent</h2>

      <label>
        ID Adhérent :
        <input
          type="number"
          value={memberId}
          onChange={(e) => setMemberId(Number(e.target.value))}
        />
      </label>

      <p>Total : {penalties.toFixed(2)} €</p>
    </div>
  );
}



