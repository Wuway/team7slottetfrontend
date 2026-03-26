using Microsoft.AspNetCore.Mvc;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicationDosageController : ControllerBase
{
    //public IActionResult Index()
    //{
    //    return View();
    //}

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMedicationDosage(int id)
    {
        MedicationDosage dosage = new MedicationDosage()
        {
            Id = 1,
            Dosage = "2 mg"
        };

        return Ok(dosage);
    }

    [HttpGet]
    public IActionResult GetAllMedicationDosages()
    {



        List<MedicationDosage> dosages = new List<MedicationDosage>();
        dosages.Add(new MedicationDosage()
        {
            Id = 1,
            Dosage = "2 mg"
        });
        dosages.Add(new MedicationDosage()
        {
            Id = 2,
            Dosage = "12 ug"
        });
        dosages.Add(new MedicationDosage()
        {
            Id = 3,
            Dosage = "3 piller"
        });



        return Ok(dosages);
    }
}
