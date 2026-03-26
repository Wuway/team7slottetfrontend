using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicationController : ControllerBase
{

    // Mangler Post, Put og Delete controlser
    // Controler er hardcoded til første prototype ittereation

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedication(int id)
    {
        Medication medication = new Medication()
        {
            Id = 1,
            PrepName = "Fentanyl"
        };

        return Ok(medication);
    }

    [HttpGet]
    public IActionResult GetAllResidents()
    {

        

        List<Medication> medications = new List<Medication>();
        medications.Add(new Medication()
        {
            Id = 1,
            PrepName = "Fentanyl"
        });
        medications.Add(new Medication()
        {
            Id = 2,
            PrepName = "Panodil"
        });
        medications.Add(new Medication()
        {
            Id = 3,
            PrepName = "Placebo"
        });



        return Ok(medications);
    }

}
