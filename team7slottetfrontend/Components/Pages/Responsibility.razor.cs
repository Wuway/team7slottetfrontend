using Microsoft.AspNetCore.Components;
using slotlib.Enums;
using slotlib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace team7slottetfrontend.Components.Pages
{
    public partial class Responsibility : ComponentBase
    {
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
        protected override void OnInitialized()
        {
            LoadMockEmployees();

            int currentHour = DateTime.Now.Hour;
            if (currentHour >= 7 && currentHour < 15)
                SetShift(ShiftType.Morgen);
            else if (currentHour >= 15 && currentHour < 23)
                SetShift(ShiftType.Eftermiddag);
            else
                SetShift(ShiftType.Nat);
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

        // TODO (API): POST /responsibilities
        private void SaveTask()
        {
            if (!string.IsNullOrWhiteSpace(newTaskName))
            {
                int newId = currentTasks.Any() ? currentTasks.Max(t => t.Id) + 1 : 1;

                var newTask = new slotlib.Models.Responsibility
                {
                    Id = newId,
                    Title = newTaskName,
                    Shift = activeShift,
                    TaskDate = currentDate.Date
                };

                currentTasks.Add(newTask);

                isAddFormVisible = false;
                newTaskName = "";
            }
        }
        #endregion

        #region Data (Mock) – skiftes til API-kald
        // TODO (API): GET /employees (til dropdown)
        private void LoadMockEmployees()
        {
            employees = new List<User>
            {
                new User { Id = 1, FirstName = "Bjarne", LastName = "Brup", Alias = "Bjerget" },
                new User { Id = 2, FirstName = "Hanne", LastName = "Hansen", Alias = "Hansedanse" },
                new User { Id = 3, FirstName = "Søren", LastName = "Skole", Alias = "Banjemusen" }
            };
        }

        // TODO (API): GET /responsibilities?date=...&shift=...
        private void LoadTasksForCurrentShift()
        {
            currentTasks = new List<slotlib.Models.Responsibility>
            {
                new slotlib.Models.Responsibility
                {
                    Id = 1,
                    Title = "Toilet rengøring",
                    UserId = 1,
                    Shift = activeShift,
                    TaskDate = currentDate.Date
                },
                new slotlib.Models.Responsibility
                {
                    Id = 2,
                    Title = "Tjekke medicinskab",
                    UserId = 2,
                    Shift = activeShift,
                    TaskDate = currentDate.Date
                }
            };
        }
        #endregion

        #region Dato + vagt (navigation/valg)
        private void GoToPreviousDay()
        {
            currentDate = currentDate.AddDays(-1);
            LoadTasksForCurrentShift();
        }

        private void GoToNextDay()
        {
            currentDate = currentDate.AddDays(1);
            LoadTasksForCurrentShift();
        }

        private void OnDateChanged(DateTime next)
        {
            currentDate = next;
            LoadTasksForCurrentShift();
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
            LoadTasksForCurrentShift();
        }
        #endregion

        #region Tabel handlinger (sortér/slet)
        private void MoveTaskUp(slotlib.Models.Responsibility task)
        {
            int index = currentTasks.IndexOf(task); // Find indekset for den aktuelle opgave
            if (index > 0)
            {
                var temp = currentTasks[index - 1]; // Gem den forrige opgave
                currentTasks[index - 1] = task; // Flyt den aktuelle opgave op
                currentTasks[index] = temp; // Flyt den tidligere opgave ned
            }
        }

        private void MoveTaskDown(slotlib.Models.Responsibility task)
        {
            int index = currentTasks.IndexOf(task);
            if (index < currentTasks.Count - 1)
            {
                var temp = currentTasks[index + 1];
                currentTasks[index + 1] = task;
                currentTasks[index] = temp; 
            }
        }

        private void DeleteTask(slotlib.Models.Responsibility task)
        {
            currentTasks.Remove(task);
        }
        #endregion
    }
}
