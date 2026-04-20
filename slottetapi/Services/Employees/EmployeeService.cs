using Microsoft.EntityFrameworkCore;
using slotlib.data;
using slotlib.DTOs.EmployePage;
using slotlib.Models;

namespace slottetapi.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _db;

    public EmployeeService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<List<EmployePageDTO.EmployeeDto>> GetAllAsync(string? search)
    {
        var q = _db.Users.AsNoTracking();
        if (!string.IsNullOrWhiteSpace(search))
        {
            q = q.Where(u =>
                u.FirstName.Contains(search) ||
                u.LastName.Contains(search) ||
                u.Alias.Contains(search));
        }

        return await q
            .OrderBy(u => u.FirstName).ThenBy(u => u.LastName)
            .Select(u => new EmployePageDTO.EmployeeDto(u.Id, u.FirstName, u.LastName, u.Alias, u.Role, u.ActiveDeactive))
            .ToListAsync();
    }

    public async Task<EmployePageDTO.EmployeeDto?> GetByIdAsync(int id)
    {
        var u = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        if (u is null) return null;
        return new EmployePageDTO.EmployeeDto(u.Id, u.FirstName, u.LastName, u.Alias, u.Role, u.ActiveDeactive);
    }

    public async Task<EmployePageDTO.EmployeeDto> CreateAsync(EmployePageDTO.CreateEmployeeRequest req)
    {
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

        return new EmployePageDTO.EmployeeDto(u.Id, u.FirstName, u.LastName, u.Alias, u.Role, u.ActiveDeactive);
    }

    public async Task<bool> UpdateAsync(int id, EmployePageDTO.UpdateEmployeeRequest req)
    {
        var u = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (u is null) return false;

        u.FirstName = req.FirstName;
        u.LastName = req.LastName;
        u.Alias = req.Alias;
        u.Role = req.Role;
        if (!string.IsNullOrWhiteSpace(req.Password))
        {
            u.Password = req.Password;
        }

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SetActiveAsync(int id, EmployePageDTO.SetEmployeeActiveRequest req)
    {
        var u = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (u is null) return false;

        u.ActiveDeactive = req.ActiveDeactive;
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var u = await _db.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (u is null) return false;

        _db.Users.Remove(u);
        await _db.SaveChangesAsync();
        return true;
    }
}

