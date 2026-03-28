namespace team7slottetfrontend.Components.Pages
{
    public partial class ResidentAdministration
    {
        private List<Resident> residents = new List<Resident>
    {
        new Resident { Name = "Susanne Pedersen", Initials = "S. P.", MedicationTimes = new List<string> { "8:30", "12:00", "14:00" } },
        new Resident { Name = "Adam Lange", Initials = "A. L.", MedicationTimes = new List<string> { "8:30", "12:00", "14:00" } },
        new Resident { Name = "Kathrine Møregård", Initials = "K. N.", MedicationTimes = new List<string> { "8:30", "14:00" } },
        new Resident { Name = "Benjamin Button", Initials = "B. B.", MedicationTimes = new List<string> { "8:30", "12:00", "14:00" } },
        new Resident { Name = "Leroy  Jenkins", Initials = "L. J.", MedicationTimes = new List<string> { "12:00", "14:00" } },
        new Resident { Name = "Frans Franskmand", Initials = "F. F.", MedicationTimes = new List<string> { "8:30", "12:00", "14:00" } }
    };

        public class Resident
        {
            public string Name { get; set; }
            public string Initials { get; set; }
            public List<string> MedicationTimes { get; set; } = new();
        }
    }
}