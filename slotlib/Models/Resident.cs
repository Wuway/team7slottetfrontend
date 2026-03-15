using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slotlib.Models
{
    public class Resident
    {
        private int _id;
        public int Id { get; set; }

        private int _socialSecurityNumber;
        public int SocialSecurityNumber { get; set; }
        
        private string _firstName;
        public string FirstName { get; set; }

        private string _lastName;
        public string LastName { get; set; }

        private string _shoppingDay;
        public string ShoppingDay { get; set; }

        private string _paymentMethod;
        public string PaymentMethod { get; set; }

        private string _alias;
        public string Alias { get; set; }

        private string _status;
        public string Status { get; set; }
    }
}
