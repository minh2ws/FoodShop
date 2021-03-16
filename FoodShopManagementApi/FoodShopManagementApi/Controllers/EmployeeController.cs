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
       
        

        public EmployeeController(IConfiguration config)
        {
            _config = config;
        }

        public bool ValidateToken()
        {
            var header = HttpContext.Request.Headers;//doc header cua request
            header.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value);
            bool isValid = JwtUtil.ValidateJSONWebToken(value, _config);
            return isValid;
        }

        [HttpPost("Employee/Insert")]
        [Produces("application/json")]
        
        public IActionResult AddEmployee([FromBody] TblEmployeesDTO Employee)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblEmployeesDAO dao = new TblEmployeesDAO();
                IActionResult response = Unauthorized();
                try
                {
                    bool result = dao.AddEmployee(Employee);
                    if (result == true)
                    {
                        return Ok(Employee);
                    }

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
                return Unauthorized();
            
        }
    }
}
