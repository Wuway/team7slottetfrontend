using System;

namespace slotlib.Data;

public class AppDbContext
{
 // Skal på sigt arve fra DbContext og indeholde DbSet<User>, DbSet<ShiftTask> osv. for at kunne håndtere data via Entity Framework Core
 // Kan være den skal i sit egne projekt (f.eks. slotlib.Data) for at undgå afhængighedsproblemer med API-projektet
}
