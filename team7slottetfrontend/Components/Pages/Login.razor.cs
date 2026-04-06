using Microsoft.AspNetCore.Components;

namespace team7slottetfrontend.Components.Pages
{
    public partial class Login : ComponentBase
    {
        protected string Username { get; set; } = "";
        protected string Password { get; set; } = "";
        protected string ErrorMessage { get; set; } = "";

        protected void LoginUser()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                ErrorMessage = "Udfyld både brugernavn og kodeord.";
                return;
            }

            ErrorMessage = "";
        }
    }
}