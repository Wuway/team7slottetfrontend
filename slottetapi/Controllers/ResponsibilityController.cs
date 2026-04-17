using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slotlib.DTOs.Responsibility;
using slotlib.Enums;
using slotlib.data;
using slotlib.Models;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsibilityController : ControllerBase
{
    public readonly AppDbContext _db;

    public ResponsibilityController(AppDbContext db) => _db = db; // Dependency Injection: AppDbContext bliver injiceret i controlleren, hvilket gør det muligt at interagere med databasen.

    // Dato og skift.
    [HttpGet] // GET: Betyder at denne metode håndterer HTTP GET-anmodninger, som typisk bruges til at hente data. I dette tilfælde henter den en liste over ansvar baseret på de angivne dato og skift.
  public async Task<ActionResult<List<ResponsibilityDTO.ResponsibilityDto>>> GetAll( //Hent alle ansvar for en given dag og skift. Resultatet sorteres efter SortOrder og derefter Id for at sikre en stabil sortering.
    [FromQuery] DateTime date,
    [FromQuery] ShiftType shift)
{
    var day = date.Date;

    // Find templates der gælder for dagen (StartDate <= day) og er aktive.
    var templates = await _db.ResponsibilityTemplates
        .AsNoTracking()
        .Where(t => t.IsActive && t.StartDate.Date <= day)
        .OrderBy(t => t.Id)
        .ToListAsync();

    // Find eksisterende instances for day+shift
    var existing = await _db.Responsibilities
        .Where(r => r.TaskDate == day && r.Shift == shift)
        .ToListAsync();

    // Opret manglende instances (pr template)
    var existingTemplateIds = existing.Select(e => e.TemplateId).ToHashSet();
    if (templates.Count > 0)
    {
        int nextSort = existing.Any() ? existing.Max(x => x.SortOrder) : 0;
        var toAdd = new List<Responsibility>();

        foreach (var t in templates)
        {
            if (existingTemplateIds.Contains(t.Id)) continue;

            nextSort++;
            toAdd.Add(new Responsibility
            {
                TemplateId = t.Id,
                Title = t.Title,
                TaskDate = day,
                Shift = shift,
                SortOrder = nextSort,
                UserId = null,
                IsCompleted = false
            });
        }

        if (toAdd.Count > 0)
        {
            _db.Responsibilities.AddRange(toAdd);
            await _db.SaveChangesAsync();
            existing.AddRange(toAdd);
        }
    }

    var items = existing
        .OrderBy(r => r.SortOrder).ThenBy(r => r.Id)
        .Select(r => new ResponsibilityDTO.ResponsibilityDto(
            r.Id,
            r.TemplateId,
            r.Title,
            r.SortOrder,
            r.TaskDate,
            r.Shift,
            r.UserId,
            r.IsCompleted
        ))
        .ToList();
        return Ok(items);
    
    }

    // Opret et nyt ansvar. SortOrder sættes til max+1 for den dag+shift, så det kommer nederst i listen.
    [HttpPost] // POST: Betyder at en ny ressource oprettes. I dette tilfælde oprettes et nyt ansvar baseret på de data, der sendes i anmodningens brødtekst (body).
    public async Task<ActionResult<ResponsibilityDTO.ResponsibilityDto>> Create(
        [FromBody] ResponsibilityDTO.CreateTemplateRequest req)
    {
        var day = req.StartDate.Date;

        // Opret template (gælder fra StartDate og frem)
        var template = new ResponsibilityTemplate
        {
            Title = req.Title,
            StartDate = day,
            IsActive = true
        };
        _db.ResponsibilityTemplates.Add(template);
        await _db.SaveChangesAsync();

        // Find næste SortOrder for den dag+shift
        var nextSort = await _db.Responsibilities
            .Where(r => r.TaskDate == day && r.Shift == req.Shift)
            .Select(r => (int?)r.SortOrder)
            .MaxAsync() ?? 0;

        var entity = new Responsibility
        {
            TemplateId = template.Id,
            Title = template.Title,
            TaskDate = day,
            Shift = req.Shift,
            UserId = null,
            IsCompleted = false,
            SortOrder = nextSort + 1
        };

        _db.Responsibilities.Add(entity);
        await _db.SaveChangesAsync();

        var dto = new ResponsibilityDTO.ResponsibilityDto(
            Id: entity.Id,
            TemplateId: entity.TemplateId,
            Title: entity.Title,
            SortOrder: entity.SortOrder,
            TaskDate: entity.TaskDate,
            Shift: entity.Shift,
            UserId: entity.UserId,
            IsCompleted: entity.IsCompleted
        );
        return CreatedAtAction(nameof(GetAll), new { date = day, shift = entity.Shift }, dto);
    }
    // Rredigér titel og medarbejder
    [HttpPut("{id:int}")] // PUT: Betyder at hele ressourcen opdateres, og alle felter skal inkluderes i anmodningen. I dette tilfælde opdateres både titel og medarbejder for det ansvar, der er angivet med id'et.
    public async Task<IActionResult> Update(int id, [FromBody] ResponsibilityDTO.UpdateResponsibilityRequest req)
    {
        var entity = await _db.Responsibilities.FirstOrDefaultAsync(r => r.Id == id);
        if (entity is null) return NotFound();
        entity.Title = req.Title;
        entity.UserId = req.UserId;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // Sæt afkrysning ved gennemført
    [HttpPatch("{id:int}/completed")]
    public async Task<IActionResult> SetCompleted(int id, [FromBody] ResponsibilityDTO.SetCompletedRequest req)
    {
        var entity = await _db.Responsibilities.FirstOrDefaultAsync(r => r.Id == id);
        if (entity is null) return NotFound();
        entity.IsCompleted = req.IsCompleted;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // POST: /api/responsibilities/5/move (Up/Down) – swap SortOrder med nabo
    [HttpPost("{id:int}/move")]
    public async Task<IActionResult> Move(int id, [FromBody] ResponsibilityDTO.MoveRequest req)
    {
        var entity = await _db.Responsibilities.FirstOrDefaultAsync(r => r.Id == id);
        if (entity is null) return NotFound();
        var day = entity.TaskDate.Date;
        var shift = entity.Shift;

        // find nabo baseret på direction
        Responsibility? neighbor = req.Direction == ResponsibilityDTO.MoveDirection.Up
            ? await _db.Responsibilities
                .Where(r => r.TaskDate == day && r.Shift == shift && r.SortOrder < entity.SortOrder)
                .OrderByDescending(r => r.SortOrder)
                .FirstOrDefaultAsync()
            : await _db.Responsibilities
                .Where(r => r.TaskDate == day && r.Shift == shift && r.SortOrder > entity.SortOrder)
                .OrderBy(r => r.SortOrder)
                .FirstOrDefaultAsync();

        if (neighbor is null) return NoContent(); // allerede øverst/nederst
        (entity.SortOrder, neighbor.SortOrder) = (neighbor.SortOrder, entity.SortOrder);
        
        await _db.SaveChangesAsync();
        
        return NoContent();
    }
    // DELETE: /api/responsibilities/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _db.Responsibilities.FirstOrDefaultAsync(r => r.Id == id);
        if (entity is null) return NotFound();
        _db.Responsibilities.Remove(entity);
        await _db.SaveChangesAsync();
        return NoContent();
    }
    
    
}
