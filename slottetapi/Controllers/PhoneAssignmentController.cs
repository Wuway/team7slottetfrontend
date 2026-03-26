using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PhoneAssignmentController : ControllerBase
{
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPhoneAssignment(int id)
    {
        PhoneAssignment phoneAssignment = new PhoneAssignment()
        {
            Id = 1,
            PhoneNumber = 12345678
        };

        return Ok(phoneAssignment);
    }

    [HttpGet]
    public IActionResult GetAllPhoneAssignments()
    {



        List<PhoneAssignment> phoneAssignments = new List<PhoneAssignment>();
        phoneAssignments.Add(new PhoneAssignment()
        {
            Id = 1,
            PhoneNumber = 87654321
        });
        phoneAssignments.Add(new PhoneAssignment()
        {
            Id = 2,
            PhoneNumber = 13243546
        });
        phoneAssignments.Add(new PhoneAssignment()
        {
            Id = 3,
            PhoneNumber = 86754231
        });



        return Ok(phoneAssignments);
    }
}
