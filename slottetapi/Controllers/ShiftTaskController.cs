using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftTaskController : ControllerBase
{
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(int id)
    {
        ShiftTask shiftTask = new ShiftTask()
        {
            Id = 1,
            Description = "Køb ind",
            Done = false,
        };

        return Ok(shiftTask);
    }

    [HttpGet]
    public IActionResult GetAllTasks()
    {



        List<ShiftTask> shiftTasks = new List<ShiftTask>();
        shiftTasks.Add(new ShiftTask()
        {
            Id = 1,
            Description = "Køb ind",
            Done = false,
        });
        shiftTasks.Add(new ShiftTask()
        {
            Id = 2,
            Description = "Luk porten",
            Done = false,
        });
        shiftTasks.Add(new ShiftTask()
        {
            Id = 3,
            Description = "Tag imod post",
            Done = false,
        });



        return Ok(shiftTasks);
    }
}
