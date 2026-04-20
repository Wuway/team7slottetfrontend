using slotlib.DTOs.Responsibility;
using slotlib.Enums;

namespace slottetapi.Services.Responsibilities;

public interface IResponsibilityService
{
    Task<List<ResponsibilityDTO.ResponsibilityDto>> GetAllAsync(DateTime date, ShiftType shift);
    Task<ResponsibilityDTO.ResponsibilityDto> CreateTemplateAsync(ResponsibilityDTO.CreateTemplateRequest req);
    Task<bool> UpdateAsync(int id, ResponsibilityDTO.UpdateResponsibilityRequest req);
    Task<bool> SetCompletedAsync(int id, ResponsibilityDTO.SetCompletedRequest req);
    Task<bool> MoveAsync(int id, ResponsibilityDTO.MoveRequest req);
    Task<bool> DeleteAsync(int id);
}

