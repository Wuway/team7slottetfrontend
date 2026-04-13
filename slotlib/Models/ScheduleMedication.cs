using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotlib.Models
{
    public class ScheduleMedication
    {
        private int _id;
        public int Id { get; set; }

        private DateTime _dispenseAt;
        public DateTime DispenseAt { get; set; }

        public bool IsGiven { get; set; }
    }
}
