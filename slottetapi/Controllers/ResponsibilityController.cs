using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsibilityController : ControllerBase
{
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetResponsibility(int id)
    {
        Responsibility responsibility = new Responsibility()
        {
            Id = 1,
            Title = "Tøm skraldespande"
        };

        return Ok(responsibility);
    }

    [HttpGet]
    public IActionResult GetAllResponsibilities()
    {



        List<Responsibility> responsibilities = new List<Responsibility>();
        responsibilities.Add(new Responsibility()
        {
            Id = 1,
            Title = "Tøm skraldespande"
        });
        responsibilities.Add(new Responsibility()
        {
            Id = 2,
            Title = "Fej gulvet"
        });
        responsibilities.Add(new Responsibility()
        {
            Id = 3,
            Title = "Lav frokost"
        });



        return Ok(responsibilities);
    }
}
