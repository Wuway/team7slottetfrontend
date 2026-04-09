namespace team7slottetfrontend.Components.Pages
{
    public partial class Plejekort
    {
        private DateTime currentDate = DateTime.Now;

        private void OnDateChanged(DateTime next)
        {
            currentDate = next;
        }
    }
}