using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_management_asp_winform.DTO
{
    class EmployeeDTO
    {
        public string empId { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool status { get; set; }
    }
}
