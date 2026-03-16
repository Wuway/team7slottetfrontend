# UC01 – Log ind

| Felt | Beskrivelse |
| :--- | :--- |
| **Use Case ID** | UC01 |
| **Navn** | Log ind |
| **Primær aktør** | Medarbejder |
| **Mål** | Medarbejderen kan logge ind i systemet for at få adgang til funktionerne. |

## Beskrivelse
Medarbejderen logger ind i systemet ved at indtaste sine loginoplysninger. Systemet validerer oplysningerne og giver adgang til systemet, hvis de er korrekte. Efter succesfuldt login sendes medarbejderen videre til dashboardet.

---

## Tasks
1. **Indtast loginoplysninger** (Medarbejderen indtaster brugernavn og adgangskode)
2. **Valider login** (Systemet kontrollerer om oplysningerne er korrekte)
3. **Giv adgang til systemet** (Hvis login er korrekt, oprettes en brugersession)
4. **Åbn dashboard** (Systemet sender medarbejderen videre til dashboardet)
5. **Fejlbesked ved forkert login** (Systemet viser fejl, hvis loginoplysninger er forkerte)