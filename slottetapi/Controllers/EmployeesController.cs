using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slotlib.data;
using slotlib.DTOs.EmployePage;
using slotlib.Enums;
using slotlib.Models;
//using slottet.Data;

namespace slottetapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _db;

        public EmployeesController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/Employees?Search=...
        [HttpGet]
        public async Task<ActionResult<List<EmployePageDTO.EmployeeDto>>> GetAll([FromQuery] string? search = null)
        {
            var q = _db.Users.AsNoTracking();
            if (!string.IsNullOrWhiteSpace(search))
            {
                q = q.Where(u =>
                    u.FirstName.Contains(search) ||
                    u.LastName.Contains(search) ||
                    u.Alias.Contains(search));
            }
            var items = await q
                .OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
                .Select(u => new EmployePageDTO.EmployeeDto(u.Id, u.FirstName, u.LastName, u.Alias, u.Role, u.ActiveDeactive))
                .ToListAsync();
            return Ok(items);
        }

         // GET: /api/employees/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployePageDTO.EmployeeDto>> GetById(int id)
    {
        var u = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (u is null) return NotFound();
        return Ok(new EmployePageDTO.EmployeeDto(u.Id, u.FirstName, u.LastName, u.Alias, u.Role, u.ActiveDeactive));
    }
    // POST: /api/employees
    [HttpPost]
    public async Task<ActionResult<EmployePageDTO.EmployeeDto>> Create([FromBody] EmployePageDTO.CreateEmployeeRequest req)
    {
        // TODO: valider password-længde (6) + evt. hash (ikke gem plaintext i prod)
        var u = new User
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            Alias = req.Alias,
            Password = req.Password,
            Role = req.Role,
            ActiveDeactive = true
        };
        _db.Users.Add(u);
        await _db.SaveChangesAsync();
        var dto = new EmployePageDTO.EmployeeDto(u.Id, u.FirstName, u.LastName, u.Alias, u.Role, u.ActiveDeactive);
        return CreatedAtAction(nameof(GetById), new { id = u.Id }, dto);
    }
    // PUT: /api/employees/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] EmployePageDTO.UpdateEmployeeRequest req)
    {
        var u = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (u is null) return NotFound();
        u.FirstName = req.FirstName;
        u.LastName = req.LastName;
        u.Alias = req.Alias;
        u.Role = req.Role;
        if (!string.IsNullOrWhiteSpace(req.Password))
        {
            u.Password = req.Password; // TODO: hash i prod
        }
        await _db.SaveChangesAsync();
        return NoContent();
    }
    // PATCH: /api/employees/5/active
    [HttpPatch("{id:int}/active")]
    public async Task<IActionResult> SetActive(int id, [FromBody] EmployePageDTO.SetEmployeeActiveRequest req)
    {
        var u = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (u is null) return NotFound();
        u.ActiveDeactive = req.ActiveDeactive;
        await _db.SaveChangesAsync();
        return NoContent();
    }
    // DELETE: /api/employees/5
    [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (u is null) return NotFound();
            _db.Users.Remove(u);
            await _db.SaveChangesAsync();
            return NoContent();
        }


    }
}
