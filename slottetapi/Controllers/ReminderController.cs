using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReminderController : ControllerBase
{
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReminder(int id)
    {
        Reminder reminder = new Reminder()
        {
            Id = 1,
            Title = "Ingen rygning på gangen"
        };

        return Ok(reminder);
    }

    [HttpGet]
    public IActionResult GetAllReminders()
    {



        List<Reminder> reminders = new List<Reminder>();
        reminders.Add(new Reminder()
        {
            Id = 1,
            Title = "Ingen rygning på gangen"
        });
        reminders.Add(new Reminder()
        {
            Id = 2,
            Title = "Husk medicin tider"
        });
        reminders.Add(new Reminder()
        {
            Id = 3,
            Title = "Sengetid er 22:30"
        });



        return Ok(reminders);
    }
}
