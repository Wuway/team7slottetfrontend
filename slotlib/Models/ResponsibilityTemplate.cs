using System;
using System.Collections.Generic;

namespace slotlib.Models;

public class ResponsibilityTemplate // Skabelon for en opgave, som kan instansieres flere gange (f.eks. hver dag)
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; } = true;

    public List<Responsibility> Instances { get; set; } = new();
}

