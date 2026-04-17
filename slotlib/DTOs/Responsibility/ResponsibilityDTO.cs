using System;
using slotlib.Enums;

namespace slotlib.DTOs.Responsibility;

public static class ResponsibilityDTO
{
    //Hvad bliver vist i listen på siden
    public record ResponsibilityDto(
        int Id,
        int TemplateId,
        string Title,
        int SortOrder,
        DateTime TaskDate,
        ShiftType Shift,
        int? UserId,
        bool IsCompleted
    );

    //Opretning af opgave (template). Instance oprettes for den aktive TaskDate + Shift.
    public record CreateTemplateRequest(
        string Title,
        DateTime StartDate,
        ShiftType Shift
    );

    //Opdatering af ansvar
    public record UpdateResponsibilityRequest(
        string Title,        
        int? UserId
    );

    //Status på toggle
    public record SetCompletedRequest(bool IsCompleted);

    //Byt rundt på ansvar
    public record MoveRequest(MoveDirection Direction);

    //Retning for at flytte ansvar i listen
    public enum MoveDirection
    {
        Up = 0,
        Down = 1
    }
}
