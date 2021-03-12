using DTO;
using FoodShopManagementApi.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost("Employee/Insert")]
        [Produces("application/json")]
        public IActionResult AddEmployee([FromBody] TblEmployeesDTO Employee)
        {
            TblEmployeesDAO dao = new TblEmployeesDAO();
            try
            {
                bool result  = dao.AddEmployee(Employee);
                if (result ==true) return Ok();
                else return Unauthorized();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Unauthorized();
        }
    }
}
