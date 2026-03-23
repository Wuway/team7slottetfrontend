namespace team7slottetfrontend.Components.Pages
{
    public partial class Responsibility
    {
        #region Kode for Tilføj knap.        
        private bool isAddFormVisible = false;
            
            private string newTaskName = ""; // Gemmer det tekst, brugeren skriver

            private void ToggleAddForm() // Åbner/lukker vinduet, når man trykker på "Tilføj Ansvar"
            {
                isAddFormVisible = !isAddFormVisible; 
            }

            private void CancelAdd() // Nulstiller feltet og lukker vinduet, når man trykker "Annuller"
            {
                isAddFormVisible = false;
                newTaskName = "";
            }

            
            private void SaveTask() // Håndterer gem-funktionen
            {
                if (!string.IsNullOrWhiteSpace(newTaskName)) // Tjekker at brugeren faktisk har skrevet noget (ikke bare mellemrum)
                {
                    // Her skal connection til en service der får det til at connecte til API og så gemme det i databasen. Det er ikke implementeret endnu, da vi ikke har en service endnu.

                    // Bagefter lukker vi vinduet og gør klar til næste gang
                    isAddFormVisible = false;
                    newTaskName = "";
                }
            }
        #endregion
    }
}
