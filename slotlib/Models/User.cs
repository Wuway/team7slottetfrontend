using slotlib.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotlib.Models
{
    public class User
    {
       public int Id { get; set; }

        [Required(ErrorMessage = "Fornavn er påkrævet.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Efternavn er påkrævet.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Alias er påkrævet.")]
        public string Alias { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kode er påkrævet.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Koden skal bestå af præcis 6 tegn.")]
        public string Password { get; set; } = string.Empty; 

        public UserRole Role { get; set; }

        public bool ActiveDeactive { get; set; } = true;

        public List<Responsibility> Responsibilities { get; set; } = new();
    }
}
