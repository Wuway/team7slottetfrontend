using Microsoft.AspNetCore.Components;
using slotlib.Models;
using slotlib.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team7slottetfrontend.Components.Pages
{
    public partial class EmployePage : ComponentBase
    {
        #region Fields / Properties
        public List<User> Employees { get; private set; } = new List<User>();
        public User newEmployee = new User();
        private bool isEditing = false;
        private bool isAddEmployeeFormVisible = false;
        private string searchTerm = string.Empty;
        private UserRole[] AvailableRoles;
        private bool showDeleteConfirmation = false;
        private User employeeToDelete;
        #endregion

        #region Lifecycle
        protected override void OnInitialized()
        {
            AvailableRoles = (UserRole[])Enum.GetValues(typeof(UserRole));
            LoadMockEmployees();
        }
        #endregion

        #region Data (Mock) – skiftes til API-kald
        // TODO (API): Erstat LoadMockEmployees() med kald til backend (GET /employees)
        private void LoadMockEmployees()
        {
            Employees = new List<User>
            {
                new User { Id = 1, FirstName = "Peter", LastName = "Pan", Alias = "Pande", Password = "123456", Role = UserRole.Administrator, ActiveDeactive = true },
                new User { Id = 2, FirstName = "Kaptajn", LastName = "Klo", Alias = "Kloen", Password = "654321", Role = UserRole.Medicinansvarlig, ActiveDeactive = true },
                new User { Id = 3, FirstName = "Anders", LastName = "And", Alias = "Rappen", Password = "112233", Role = UserRole.Plejepersonale, ActiveDeactive = false },
                new User { Id = 4, FirstName = "Mickey", LastName = "Mouse", Alias = "Musen", Password = "445566", Role = UserRole.Vikar, ActiveDeactive = true }
            };
        }
        #endregion

        #region UI-handling (Form + Actions)
        private void HandleSubmit()
        {
            if (isEditing)
            {
                UpdateEmployee();
            }
            else
            {
                AddNewEmployee();
            }
        }

        // TODO (API): POST /employees
        private void AddNewEmployee()
        {
            newEmployee.Id = Employees.Any() ? Employees.Max(e => e.Id) + 1 : 1;
            newEmployee.ActiveDeactive = true;
            Employees.Add(newEmployee);
            ClearForm(); // gem -> luk formularen og ryd input
        }

        private void EditEmployee(User user)
        {
            newEmployee = new User { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Alias = user.Alias, Password = user.Password, Role = user.Role, ActiveDeactive = user.ActiveDeactive };
            isEditing = true;
            isAddEmployeeFormVisible = true;
        }

        // TODO (API): PUT/PATCH /employees/{id}
        private void UpdateEmployee()
        {
            var employeeToUpdate = Employees.FirstOrDefault(e => e.Id == newEmployee.Id);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.FirstName = newEmployee.FirstName;
                employeeToUpdate.LastName = newEmployee.LastName;
                employeeToUpdate.Alias = newEmployee.Alias;
                employeeToUpdate.Password = newEmployee.Password;
                employeeToUpdate.Role = newEmployee.Role;
            }
            ClearForm();
        }

        private void ConfirmDelete(User user)
        {
            employeeToDelete = user;
            showDeleteConfirmation = true;
        }

        private void CancelDelete()
        {
            employeeToDelete = null;
            showDeleteConfirmation = false;
        }

        // TODO (API): DELETE /employees/{id}
        private void ExecuteDelete()
        {
            if (employeeToDelete != null)
            {
                Employees.Remove(employeeToDelete);
            }
            CancelDelete();
        }

        private void ClearForm()
        {
            newEmployee = new User(); 
            isEditing = false;
            isAddEmployeeFormVisible = false;
        }

        private void ShowAddEmployeeForm()
        {
            newEmployee = new User();
            isEditing = false;
            isAddEmployeeFormVisible = true;
        }

        private void ToggleAddEmployeeForm()
        {
            if (isAddEmployeeFormVisible)
            {
                ClearForm();
            }
            else
            {
                ShowAddEmployeeForm();
            }
        }
        #endregion

        #region Afledt data (filtrering)
        private List<User> FilteredEmployees =>
        string.IsNullOrWhiteSpace(searchTerm)
            ? Employees
            : Employees.Where(e =>
                e.FirstName.Contains(searchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                e.LastName.Contains(searchTerm, System.StringComparison.OrdinalIgnoreCase) ||
                e.Alias.Contains(searchTerm, System.StringComparison.OrdinalIgnoreCase)).ToList();
        #endregion
    }
}
