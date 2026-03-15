using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotlib.Models
{
    public class User
    {
        private int _id;
        public int Id { get; set; }

        private string _firstName;
        public string FirstName { get; set; }

        private string _lastName;
        public string LastName { get; set; }

        private string _alias;
        public string Alias { get; set; }
    }
}
