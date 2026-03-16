# UC04 – Opdater beboerstatus (Kritisk / OBS / Stabil)

| Felt | Beskrivelse |
| :--- | :--- |
| **Use Case ID** | UC04 |
| **Navn** | Opdater beboerstatus |
| **Primær aktør** | Medarbejder |
| **Mål** | Brugeren kan hurtigt opdatere en beboers aktuelle status, så informationen vises tydeligt på displayet og gemmes for den valgte vagt. |

## Beskrivelse
På dashboardet vælger brugeren en beboer. I redigeringspanelet kan brugeren ændre beboerens status til **Kritisk**, **OBS** eller **Stabil**. Når status ændres, opdateres beboerkortets farve med det samme til rød, gul eller grøn, og ændringen gemmes på det aktuelle overlap (dato + periode). Display-skærmen viser den opdaterede status, så alle i afdelingen har samme overblik.

---

## Tasks

1. **Klik borgerkort og vælg borger**
   - Den valgte borger markeres, og redigeringspanelet åbner.
2. **Status-toggle (rød, gul, grøn)**
   - Et enkelt klik i panelet ændrer status-niveauet.
3. **Opdater farve med det samme**
   - Farven på borgerkortet skifter øjeblikkeligt i oversigten, når status ændres.
4. **Gem ændringer**
   - Status gemmes i systemet (knyttes til dato og vagtperiode).