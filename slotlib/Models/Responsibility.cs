using slotlib.Enums;

namespace slotlib.Models
{
    public class Responsibility
    {
        public int Id { get; set; }
        public int TemplateId { get; set; }
        public ResponsibilityTemplate? Template { get; set; }
        public string Title { get; set; } = string.Empty;
        public int SortOrder { get; set; }
        public DateTime TaskDate { get; set; }
        public ShiftType Shift { get; set; }
        public int? UserId { get; set; }
        public User? AssignedUser { get; set; }

        public bool IsCompleted { get; set; } // True når opgaven er markeret som udført (vises som toggle i UI)
    }
}
