using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotlib.Models
{
    public class MedicationDosage
    {
        private int _id;
        public int Id { get; set; }

        private string _dosage;
        public string Dosage { get; set; }
    }
}
