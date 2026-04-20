using slotlib.DTOs.Responsibility;
using slotlib.Enums;
using Microsoft.AspNetCore.Mvc;
using slottetapi.Services.Responsibilities;

namespace slottetapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResponsibilityController : ControllerBase
{
    private readonly IResponsibilityService _responsibilities;

    public ResponsibilityController(IResponsibilityService responsibilities) => _responsibilities = responsibilities;

    // Dato og skift.
    [HttpGet] // GET: Betyder at denne metode håndterer HTTP GET-anmodninger, som typisk bruges til at hente data. I dette tilfælde henter den en liste over ansvar baseret på de angivne dato og skift.
  public async Task<ActionResult<List<ResponsibilityDTO.ResponsibilityDto>>> GetAll( //Hent alle ansvar for en given dag og skift. Resultatet sorteres efter SortOrder og derefter Id for at sikre en stabil sortering.
    [FromQuery] DateTime date,
    [FromQuery] ShiftType shift)
{
    var items = await _responsibilities.GetAllAsync(date, shift);
    return Ok(items);
    
    }

    // Opret et nyt ansvar. SortOrder sættes til max+1 for den dag+shift, så det kommer nederst i listen.
    [HttpPost] // POST: Betyder at en ny ressource oprettes. I dette tilfælde oprettes et nyt ansvar baseret på de data, der sendes i anmodningens brødtekst (body).
    public async Task<ActionResult<ResponsibilityDTO.ResponsibilityDto>> Create(
        [FromBody] ResponsibilityDTO.CreateTemplateRequest req)
    {
        var dto = await _responsibilities.CreateTemplateAsync(req);
        return CreatedAtAction(nameof(GetAll), new { date = dto.TaskDate.Date, shift = dto.Shift }, dto);
    }
    // Rredigér titel og medarbejder
    [HttpPut("{id:int}")] // PUT: Betyder at hele ressourcen opdateres, og alle felter skal inkluderes i anmodningen. I dette tilfælde opdateres både titel og medarbejder for det ansvar, der er angivet med id'et.
    public async Task<IActionResult> Update(int id, [FromBody] ResponsibilityDTO.UpdateResponsibilityRequest req)
    {
        var ok = await _responsibilities.UpdateAsync(id, req);
        return ok ? NoContent() : NotFound();
    }

    // Sæt afkrysning ved gennemført
    [HttpPatch("{id:int}/completed")]
    public async Task<IActionResult> SetCompleted(int id, [FromBody] ResponsibilityDTO.SetCompletedRequest req)
    {
        var ok = await _responsibilities.SetCompletedAsync(id, req);
        return ok ? NoContent() : NotFound();
    }

    // POST: /api/responsibilities/5/move (Up/Down) – swap SortOrder med nabo
    [HttpPost("{id:int}/move")]
    public async Task<IActionResult> Move(int id, [FromBody] ResponsibilityDTO.MoveRequest req)
    {
        var ok = await _responsibilities.MoveAsync(id, req);
        return ok ? NoContent() : NotFound();
    }
    // DELETE: /api/responsibilities/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var ok = await _responsibilities.DeleteAsync(id);
        return ok ? NoContent() : NotFound();
    }
    
    
}
