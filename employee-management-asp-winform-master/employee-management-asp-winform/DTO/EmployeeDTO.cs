using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee_management_asp_winform.DTO
{
    class EmployeeDTO
    {
        public string idEmployee { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public bool status { get; set; }
    }
}
