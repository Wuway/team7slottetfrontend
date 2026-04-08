namespace team7slottetfrontend.Components.Pages
{
    public partial class PhonePage
    {
        private List<Phone> phones = new List<Phone>
        {
            new Phone { PhoneNumber = "457623", Type = "Vagt", User = "Jens O" },
            new Phone { PhoneNumber = "457624", Type = "Reserve", User = "Anna M" },
            new Phone { PhoneNumber = "457625", Type = "Vagt", User = "Mia K" }
        };

        private List<string> phoneTypes = new List<string>
        {
            "Vagt",
            "Reserve",
            "Fast"
        };

        private List<string> users = new List<string>
        {
            "Jens O",
            "Anna M",
            "Mia K"
        };

        public class Phone
        {
            public string PhoneNumber { get; set; }
            public string Type { get; set; }
            public string User { get; set; }
        }
    }
}