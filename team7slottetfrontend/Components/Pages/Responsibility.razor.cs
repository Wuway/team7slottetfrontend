using Microsoft.AspNetCore.Components;
using slotlib.DTOs.EmployePage;
using slotlib.DTOs.Responsibility;
using slotlib.Enums;
using slotlib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace team7slottetfrontend.Components.Pages
{
    public partial class Responsibility : ComponentBase
    {
        [Inject] private IHttpClientFactory HttpClientFactory { get; set; } = default!;

        private HttpClient http = default!;
        private const string ResponsibilityApiBase = "api/responsibility";

        #region Felter/State (UI)
        private List<slotlib.Models.Responsibility> currentTasks = new List<slotlib.Models.Responsibility>();
        private List<User> employees = new List<User>();

        private bool isAddFormVisible = false;
        private string newTaskName = "";

        private DateTime currentDate = DateTime.Now;
        private ShiftType activeShift = ShiftType.Morgen;
        private TimeSpan shiftStart;
        private TimeSpan shiftEnd;
        #endregion

        #region Lifecycle
        protected override async Task OnInitializedAsync()
        {
            http = HttpClientFactory.CreateClient("SlottetApi");
            
            int currentHour = DateTime.Now.Hour;
            if (currentHour >= 7 && currentHour < 15)
                activeShift = ShiftType.Morgen;
            else if (currentHour >= 15 && currentHour < 23)
                activeShift = ShiftType.Eftermiddag;
            else
                activeShift = ShiftType.Nat;

            ApplyShiftWindow(activeShift);

            await LoadEmployeesAsync();
            await LoadTasksForCurrentShiftAsync();
        }
        #endregion

        #region UI-handling (Tilføj opgave)
        private void ToggleAddForm()
        {
            isAddFormVisible = !isAddFormVisible;
        }

        private void CancelAdd()
        {
            isAddFormVisible = false;
            newTaskName = "";
        }

        private async Task SaveTask()
        {
            if (string.IsNullOrWhiteSpace(newTaskName))
                return;

            var req = new ResponsibilityDTO.CreateTemplateRequest(
                Title: newTaskName.Trim(),
                StartDate: currentDate.Date,
                Shift: activeShift);

            var resp = await http.PostAsJsonAsync(ResponsibilityApiBase, req);
            resp.EnsureSuccessStatusCode();

            isAddFormVisible = false;
            newTaskName = "";
            await LoadTasksForCurrentShiftAsync();
        }
        #endregion

        #region Data (API)
        private async Task LoadEmployeesAsync()
        {
            var items = await http.GetFromJsonAsync<List<EmployePageDTO.EmployeeDto>>("api/employees") ?? new();
            employees = items.Select(e => new User
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Alias = e.Alias,
                Role = e.Role,
                ActiveDeactive = e.ActiveDeactive
            }).ToList();
        }

        private async Task LoadTasksForCurrentShiftAsync()
        {
            var date = Uri.EscapeDataString(currentDate.Date.ToString("yyyy-MM-dd"));
            var shift = Uri.EscapeDataString(activeShift.ToString());
            var url = $"{ResponsibilityApiBase}?date={date}&shift={shift}";

            var items = await http.GetFromJsonAsync<List<ResponsibilityDTO.ResponsibilityDto>>(url) ?? new();

            currentTasks = items.Select(t => new slotlib.Models.Responsibility
            {
                Id = t.Id,
                TemplateId = t.TemplateId,
                Title = t.Title,
                SortOrder = t.SortOrder,
                TaskDate = t.TaskDate,
                Shift = t.Shift,
                UserId = t.UserId,
                IsCompleted = t.IsCompleted
            })
            .OrderBy(t => t.SortOrder)
            .ThenBy(t => t.Id)
            .ToList();
        }
        #endregion

        #region Dato + vagt (navigation/valg)
        
        private async Task OnDateChanged(DateTime next)
        {
            currentDate = next;
            await LoadTasksForCurrentShiftAsync();
        }

        private async Task SetShift(ShiftType shift)
        {
            activeShift = shift;
            ApplyShiftWindow(shift);
            await LoadTasksForCurrentShiftAsync();
        }

        private void ApplyShiftWindow(ShiftType shift)
        {
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
        #endregion

        #region Tabel handlinger (API)
        private async Task OnCompletedChanged(slotlib.Models.Responsibility task, bool isCompleted)
        {
            bool previous = task.IsCompleted;
            task.IsCompleted = isCompleted;

            var resp = await http.PatchAsJsonAsync(
                $"{ResponsibilityApiBase}/{task.Id}/completed",
                new ResponsibilityDTO.SetCompletedRequest(isCompleted));

            if (!resp.IsSuccessStatusCode)
            {
                task.IsCompleted = previous;
                resp.EnsureSuccessStatusCode();
            }
        }

        private async Task OnUserChanged(slotlib.Models.Responsibility task, int? userId)
        {
            int? previous = task.UserId;
            task.UserId = userId;

            var resp = await http.PutAsJsonAsync(
                $"{ResponsibilityApiBase}/{task.Id}",
                new ResponsibilityDTO.UpdateResponsibilityRequest(
                    Title: task.Title,
                    UserId: userId));

            if (!resp.IsSuccessStatusCode)
            {
                task.UserId = previous;
                resp.EnsureSuccessStatusCode();
            }
        }

        private async Task MoveTaskUp(slotlib.Models.Responsibility task)
        {
            await MoveTask(task, ResponsibilityDTO.MoveDirection.Up);
        }

        private async Task MoveTaskDown(slotlib.Models.Responsibility task)
        {
            await MoveTask(task, ResponsibilityDTO.MoveDirection.Down);
        }

        private async Task MoveTask(slotlib.Models.Responsibility task, ResponsibilityDTO.MoveDirection direction)
        {
            var resp = await http.PostAsJsonAsync(
                $"{ResponsibilityApiBase}/{task.Id}/move",
                new ResponsibilityDTO.MoveRequest(direction));
            resp.EnsureSuccessStatusCode();
            await LoadTasksForCurrentShiftAsync();
        }

        private async Task DeleteTask(slotlib.Models.Responsibility task)
        {
            var resp = await http.DeleteAsync($"{ResponsibilityApiBase}/{task.Id}");
            resp.EnsureSuccessStatusCode();
            await LoadTasksForCurrentShiftAsync();
        }
        #endregion
    }
}
