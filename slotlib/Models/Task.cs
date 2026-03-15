using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotlib.Models
{
    public class Task
    {
        private int _id;
        public int Id { get; set; }

        private string _description;
        public string Description { get; set; }

        private bool _done;
        public bool Done { get; set; }
    }
}
