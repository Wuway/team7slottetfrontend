namespace team7slottetfrontend.Components.Pages
{
    public partial class LogPage
    {
        private DateTime currentDate = DateTime.Now;
        private void OnDateChanged(DateTime next)
        {
            currentDate = next;
        }
        private List<LogEntry> logs = new List<LogEntry>
        {
            new LogEntry
            {
                Time = "08:15",
                Employee = "Jens O",
                Action = "Oprettet",
                Details = "Ny vagttelefon registreret",
                Type = "Telefon",
                Id = "101"
            },
            new LogEntry
            {
                Time = "09:02",
                Employee = "Anna M",
                Action = "Redigeret",
                Details = "Beboerinformation opdateret",
                Type = "Beboer",
                Id = "102"
            },
            new LogEntry
            {
                Time = "10:30",
                Employee = "Mia K",
                Action = "Slettet",
                Details = "Ansvarsrolle fjernet",
                Type = "Ansvar",
                Id = "103"
            }
        };

        public class LogEntry
        {
            public string Time { get; set; }
            public string Employee { get; set; }
            public string Action { get; set; }
            public string Details { get; set; }
            public string Type { get; set; }
            public string Id { get; set; }
        }
    }
}