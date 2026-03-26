using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientTimeController : ControllerBase
{
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPT(int id)
    {
        PatientTime pt = new PatientTime()
        {
            Id = 1,
            DispensedAt = DateTime.Now,
            TimeBetweenDosis = TimeOnly.Parse("20"),
            Note = ""
        };

        return Ok(pt);
    }

    [HttpGet]
    public IActionResult GetAllPT()
    {



        List<PatientTime> pt = new List<PatientTime>();
        pt.Add(new PatientTime()
        {
            Id = 1,
            DispensedAt = DateTime.Now,
            TimeBetweenDosis = TimeOnly.Parse("20"),
            Note = ""
        });
        pt.Add(new PatientTime()
        {
            Id = 2,
            DispensedAt = DateTime.Now,
            TimeBetweenDosis = TimeOnly.Parse("60"),
            Note = ""
        });
        pt.Add(new PatientTime()
        {
            Id = 3,
            DispensedAt = DateTime.Now,
            TimeBetweenDosis = TimeOnly.Parse("180"),
            Note = "Kun p[ regnvjers dage"
        });



        return Ok(pt);
    }
}
