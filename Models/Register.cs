using System;
using System.Collections.Generic;

#nullable disable

namespace Registermvc.Models
{
    public partial class Register
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public decimal GrossIncome { get; set; }
        public decimal NetIncome { get; set; }
        public string PhoneNumber { get; set; }
    }
}
