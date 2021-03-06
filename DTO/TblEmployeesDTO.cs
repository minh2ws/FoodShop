using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TblEmployeesDTO
    {
        public string idEmployee { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public bool status { get; set; }
    }
}
