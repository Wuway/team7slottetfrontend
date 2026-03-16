# UC03 – Se og navigere på dashboard

| Felt | Beskrivelse |
| :--- | :--- |
| **Use Case ID** | UC03 |
| **Navn** | Se og navigere på dashboard |
| **Primær aktør** | Medarbejder |
| **Mål** | Brugeren får hurtigt overblik over det aktuelle overlap og kan navigere frit i dato og vagtperiode. |

## Beskrivelse
Efter login lander brugeren på dashboardet med aktuel dato og en automatisk valgt periode baseret på klokkeslættet: Morgen (07-15), Aften (15-23) eller Nat (23-07). Brugeren skal kunne skifte til forrige eller næste dag og hurtigt vende tilbage til dags dato. Dashboardet henter eller opretter Shift og Overlap for den valgte dato og periode og viser relevante borgerkort, statusser, vagthold (telefonliste) og særligt ansvarlige.

---

## Tasks

1. **Til Dashboard: dato + periode + visning**
   - Systemet indlæser dashboard-visningen med korrekte parametre.
2. **Dashboard top: dato + periode**
   - Viser den valgte dato og vagtperiode øverst i interface.
3. **Auto-periode ud fra klokkeslæt**
   - Morgen/aften/nat vælges automatisk ud fra tid, men kan ændres manuelt af brugeren.
4. **Vis borgerkort på dashboard**
   - Systemet henter og viser relevante borgerkort for det valgte overlap.
5. **Dato-navigation**
   - Brugeren kan navigere via knapper (forrige dag / "i dag" / næste dag).