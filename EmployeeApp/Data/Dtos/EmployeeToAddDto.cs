using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Data.Dtos
{
    public class EmployeeToAddDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Address { get; set; }
        public string Salary { get; set; }
        public string PhoneNmber { get; set; }
    }
}
