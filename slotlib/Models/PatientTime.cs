using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotlib.Models
{
    public class PatientTime
    {
        private int _id;
        public int Id { get; set; }

        private DateTime _dispensedAt;
        public DateTime DispensedAt { get; set; }

        private TimeOnly _timeBetweenDosis;
        public TimeOnly TimeBetweenDosis { get; set; }

        private string _note;
        public string Note { get; set; }
    }
}
