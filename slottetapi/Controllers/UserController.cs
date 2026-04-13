using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        User user = new User()
        {
            Id = 1,
            FirstName = "Henning",
            LastName = "Pedersen",
            Alias = "HePe"
        };

        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAllUsers()
    {



        List<User> users = new List<User>();
        users.Add(new User()
        {
            Id = 1,
            FirstName = "Henning",
            LastName = "Pedersen",
            Alias = "HePe"
        });
        users.Add(new User()
        {
            Id = 2,
            FirstName = "Lone",
            LastName = "Frederiksen",
            Alias = "LoFr"
        });
        users.Add(new User()
        {
            Id = 3,
            FirstName = "Stig",
            LastName = "Openheimer",
            Alias = "StOp"
        });



        return Ok(users);
    }
}
