using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.DTO
{
    public class TblEmployeesDTO
    {
        public int IdEmployee { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool status { get; set; }
    }
}
