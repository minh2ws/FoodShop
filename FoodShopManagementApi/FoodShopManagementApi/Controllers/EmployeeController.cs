using DTO;
using FoodShopManagementApi.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodShopManagementApi.Util;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IConfiguration _config;
        [HttpPost("Employee/Insert")]
        [Produces("application/json")]
        public IActionResult AddEmployee([FromBody] TblEmployeesDTO Employee)
        {
            TblEmployeesDAO dao = new TblEmployeesDAO();
            IActionResult response = Unauthorized();
            try
            {
                bool result  = dao.AddEmployee(Employee);
                if (result ==true)
                {
                    string token = JwtUtil.GenerateJSONWebToken(Employee, _config);
                    response = Ok(new { token = token });
                }
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Unauthorized();
        }
    }
}
