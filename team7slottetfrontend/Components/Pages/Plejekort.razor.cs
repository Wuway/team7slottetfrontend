using slotlib.Enums;
using slotlib.Models;
using team7slottetfrontend.Components.Partials;

namespace team7slottetfrontend.Components.Pages
{
    public partial class Plejekort
    {
        private DateTime currentDate = DateTime.Today;

        private ResidentPicker.ResidentItem? selectedPickerResident;
        private Resident? currentResident;

        private List<ResidentPicker.ResidentItem> pickerResidents = new()
    {
        new() { Name = "Anne Rasmussen",     Status = RiskIndicator.High   },
        new() { Name = "Jens Jensen",         Status = RiskIndicator.Low    },
        new() { Name = "Adam Lauge",          Status = RiskIndicator.Middle },
        new() { Name = "Katrine Nøregaard",   Status = RiskIndicator.Low    },
        new() { Name = "Lotte Johansen",      Status = RiskIndicator.High   },
        new() { Name = "Tue Hansen",          Status = RiskIndicator.Low    },
        new() { Name = "Nicolai Frederiksen", Status = RiskIndicator.Middle },
        new() { Name = "Sabrina Viola",       Status = RiskIndicator.Low    },
    };

        private void OnResidentSelected(ResidentPicker.ResidentItem resident)
        {
            selectedPickerResident = resident;

            // TODO: replace with API call e.g:
            // currentResident = await ApiService.GetResidentAsync(resident.Id);
            currentResident = GetDummyResident(resident);
        }

        private void OnDetailChanged(Resident updated)
        {
            currentResident = updated;

            // Sync status back to picker dot
            var match = pickerResidents.FirstOrDefault(r => r.Name == $"{updated.FirstName} {updated.LastName}");
            if (match is not null)
                match.Status = Enum.TryParse<RiskIndicator>(updated.Status, out var parsed)
                    ? parsed
                    : RiskIndicator.Low;
        }

        private void OnDateChanged(DateTime date)
        {
            currentDate = date;
            // TODO: reload currentResident for new date if one is selected
        }

        private static Resident GetDummyResident(ResidentPicker.ResidentItem item) => new()
        {
            FirstName = item.Name.Split(' ')[0],
            LastName = item.Name.Split(' ')[^1],
            Status = item.Status.ToString(),
            ScheduleMedications = new(),
            PatientTime = new(),
            ShoppingDay = "",
            ShoppingNotes = "",
            PaymentNotes = "",
            Message = ""
        };
    }
}