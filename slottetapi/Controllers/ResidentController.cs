using Microsoft.AspNetCore.Mvc;
using slotlib.Models;
using slottetapi.Models;
using System;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResidentController : ControllerBase
{
    //private readonly AppDbContext _db;

    //public ResidentController(AppDbContext db)
    //{
    //    _db = db;
    //}

    public ResidentController() { }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetResident(int id) 
    {

        // TEMP HARD DATA -- DELETE WHEN IMPLEMENTED CORRECTLY
        Resident resident = new Resident()
        {
            Id = 1,
            SocialSecurityNumber = 0101912020,
            FirstName = "John",
            LastName = "Lennon",
            ShoppingDay = "Kun om mandagen",
            PaymentMethod = "Kontanter",
            Alias = "JOLE",
            Status = ""
        };

        return Ok(resident);


        // AI Udkast til brug med EF Core
        throw new NotImplementedException();
        //var resident = await _db.Residents.FindAsync(id);
        //if (resident == null) return NotFound();
        //return Ok(resident);
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateResident(CreateResidentDto dto)
    //{
    // AI Udkast til brug med EF Core
    //var resident = new Resident
    //{
    //    FirstName = dto.FirstName,
    //    LastName = dto.LastName,
    //    Alias = dto.Alias
    //};

    //await _db.Residents.AddAsync(resident);
    //await _db.SaveChangesAsync();
    //return CreatedAtAction(nameof(GetResident), new { id = resident.Id }, resident);
    //}

    //[HttpPut("{id}")]
    //public async Task<IActionResult> UpdateResident(int id, UpdateResidentDto dto) 
    //{
    //    // AI Udkast til brug med EF Core
    //    throw new NotImplementedException();
    //    var resident = await _db.Residents.FindAsync(id);
    //    if (resident == null) return NotFound();

    //    if (dto.FirstName != null) resident.FirstName = dto.FirstName;
    //    if (dto.LastName != null) resident.LastName = dto.LastName;
    //    if (dto.Alias != null) resident.Alias = dto.Alias;

    //    await _db.SaveChangesAsync();
    //    return Ok(resident);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteResident(int id) 
    //{
    //    // AI Udkast til brug med EF Core
    //    throw new NotImplementedException();
    //    var resident = await _db.Residents.FindAsync(id);
    //    if (resident == null) return NotFound();

    //    _db.Residents.Remove(resident);
    //    await _db.SaveChangesAsync();
    //    return NoContent();
    //}

    [HttpGet]
    public IActionResult GetAllResidents()
    {

        List<Resident> residents = new List<Resident>();
        residents.Add(new Resident()
        {
            Id = 1,
            SocialSecurityNumber = 0101912020,
            FirstName = "John",
            LastName = "Lennon",
            ShoppingDay = "Kun om mandagen",
            PaymentMethod = "Kontanter",
            Alias = "JOLE",
            Status = ""
        });
        residents.Add(new Resident()
        {
            Id = 2,
            SocialSecurityNumber = 0212844422,
            FirstName = "Ringo",
            LastName = "Star",
            ShoppingDay = "Hver dag til frokost",
            PaymentMethod = "Dankort",
            Alias = "RIST",
            Status = "Er træt af at se Matlock"
        });


        return Ok(residents);
    }

}
