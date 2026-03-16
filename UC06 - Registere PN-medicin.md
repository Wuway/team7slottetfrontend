# UC06 – Registrere PN-medicin (tid + log)

| Felt | Beskrivelse |
| :--- | :--- |
| **Use Case ID** | UC06 |
| **Navn** | Registrere PN-medicin |
| **Primær aktør** | Medarbejder |
| **Mål** | Medarbejderen kan registrere givet PN-medicin med tidspunkt, så det fremgår korrekt i loggen for den valgte vagt. |

## Beskrivelse
Medarbejderen registrerer PN-medicin direkte på den enkelte beboers kort på dashboardet. Når medicinen gives, indtaster medarbejderen tidspunktet for administrationen. Systemet gemmer registreringen og opdaterer loggen for den valgte dato og periode (Shift/Overlap), så det dokumenteres korrekt.

---

## Tasks

1. **PN-knap på beboerkort**
   - Mulighed for at starte registrering af PN-medicin direkte på den enkelte beboer.
2. **Inputfelt til tidspunkt**
   - Medarbejderen indtaster tidspunktet for, hvornår medicinen er givet.
3. **Gem registrering**
   - Systemet gemmer PN-registreringen i databasen.
4. **Log registrering**
   - Tidspunkt og beboer gemmes i systemets historik/log for det aktuelle overlap.
5. **Opdater visning på dashboard**
   - Registreringen fremgår med det samme på beboerkortet eller i logvisningen.