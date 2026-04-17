using System;
using slotlib.Enums;

namespace slotlib.DTOs.EmployePage;

public class EmployePageDTO
{
    public record EmployeeDto( //record betyder at det er en immutable class, hvor properties kun kan sættes ved instansiering og ikke ændres senere. Det er ideelt til dataoverførsel, da det sikrer, at dataene forbliver konsistente og uforanderlige efter oprettelsen.
    int Id,
    string FirstName,
    string LastName,
    string Alias,
    UserRole Role,
    bool ActiveDeactive
);
public record CreateEmployeeRequest(
    string FirstName,
    string LastName,
    string Alias,
    string Password,   // 6 cifre
    UserRole Role
);
public record UpdateEmployeeRequest(
    string FirstName,
    string LastName,
    string Alias,
    UserRole Role,
    string? Password = null
);
public record SetEmployeeActiveRequest(bool ActiveDeactive);
}
