using slotlib.DTOs.EmployePage;

namespace slottetapi.Services.Employees;

public interface IEmployeeService
{
    Task<List<EmployePageDTO.EmployeeDto>> GetAllAsync(string? search); //
    Task<EmployePageDTO.EmployeeDto?> GetByIdAsync(int id);
    Task<EmployePageDTO.EmployeeDto> CreateAsync(EmployePageDTO.CreateEmployeeRequest req);
    Task<bool> UpdateAsync(int id, EmployePageDTO.UpdateEmployeeRequest req);
    Task<bool> SetActiveAsync(int id, EmployePageDTO.SetEmployeeActiveRequest req);
    Task<bool> DeleteAsync(int id);
}

