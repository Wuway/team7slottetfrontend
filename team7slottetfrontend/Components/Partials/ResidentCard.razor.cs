using Microsoft.AspNetCore.Components;

namespace team7slottetfrontend.Components.Partials
{
    public partial class ResidentCard
    {
        [Parameter] public string FullName { get; set; }
        [Parameter] public string Initials { get; set; }
        [Parameter] public List<string> MedicationTimes { get; set; } = new();
    }
}