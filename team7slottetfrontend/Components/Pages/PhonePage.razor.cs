using slotlib.Enums;

namespace team7slottetfrontend.Components.Pages;

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
    private DateTime currentDate = DateTime.Now;
    private ShiftType activeShift = ShiftType.Morgen;
    private TimeSpan shiftStart;
    private TimeSpan shiftEnd;
    private void OnDateChanged(DateTime next)
    {
        currentDate = next;
    }

    private void SetShift(ShiftType shift)
    {
        activeShift = shift;
        switch (shift)
        {
            case ShiftType.Morgen:
                shiftStart = new TimeSpan(7, 0, 0);
                shiftEnd = new TimeSpan(14, 59, 59);
                break;
            case ShiftType.Eftermiddag:
                shiftStart = new TimeSpan(15, 0, 0);
                shiftEnd = new TimeSpan(22, 59, 59);
                break;
            case ShiftType.Nat:
                shiftStart = new TimeSpan(23, 0, 0);
                shiftEnd = new TimeSpan(6, 59, 59);
                break;
        }
    }
}