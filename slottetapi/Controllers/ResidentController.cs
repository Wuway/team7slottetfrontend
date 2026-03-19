using Microsoft.AspNetCore.Mvc;
using slotlib.Models;
using slottetapi.Models;
using System;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResidentController : ControllerBase
{
    private readonly AppDbContext _db;

    public ResidentController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetResident(int id) 
    {
        // AI Udkast til brug med EF Core
        throw new NotImplementedException();
        var resident = await _db.Residents.FindAsync(id);
        if (resident == null) return NotFound();
        return Ok(resident);
    }

    [HttpPost]
    public async Task<IActionResult> CreateResident(CreateResidentDto dto)
    {
        // AI Udkast til brug med EF Core
        var resident = new Resident
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Alias = dto.Alias
        };

        await _db.Residents.AddAsync(resident);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetResident), new { id = resident.Id }, resident);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateResident(int id, UpdateResidentDto dto) 
    {
        // AI Udkast til brug med EF Core
        throw new NotImplementedException();
        var resident = await _db.Residents.FindAsync(id);
        if (resident == null) return NotFound();

        if (dto.FirstName != null) resident.FirstName = dto.FirstName;
        if (dto.LastName != null) resident.LastName = dto.LastName;
        if (dto.Alias != null) resident.Alias = dto.Alias;

        await _db.SaveChangesAsync();
        return Ok(resident);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResident(int id) 
    {
        // AI Udkast til brug med EF Core
        throw new NotImplementedException();
        var resident = await _db.Residents.FindAsync(id);
        if (resident == null) return NotFound();

        _db.Residents.Remove(resident);
        await _db.SaveChangesAsync();
        return NoContent();
    }

}
