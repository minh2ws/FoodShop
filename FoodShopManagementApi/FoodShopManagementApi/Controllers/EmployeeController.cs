using DTO;
using FoodShopManagementApi.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodShopManagementApi.Util;
using DTO.Model;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement/employee")]
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

        [HttpPost("Insert")]
        [Produces("application/json")]
        public IActionResult AddEmployee([FromBody] TblEmployeesDTO Employee)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblEmployeesDAO dao = TblEmployeesDAO.getInstance();
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

        [HttpGet("Load")]
        [Produces("application/json")]
        public IActionResult LoadEmployee([FromQuery] string role)
        {
            Boolean isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblEmployeesDAO dao = TblEmployeesDAO.getInstance();
            try
            {
                List<TblEmployeesDTO> list = dao.loadEmployee(role);
                if (list != null)
                {
                    return Ok(list);
                }
            }
            catch (Exception)
            {
                StatusCode(500);
            }
            }
            return Unauthorized();
        }

        [HttpPost("UpdateEmpDetail")]
        [Produces("application/json")]
        public IActionResult updateEmployee([FromBody] TblEmployeesDTO emp)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblEmployeesDAO dao = TblEmployeesDAO.getInstance();
                try
                {
                    bool success = dao.UpdateEmployeeDetail(emp);
                    if (success)
                    {
                        return Ok(success);
                    }
                }
                catch (Exception)
                {
                    StatusCode(500);
                }
            }
            return Unauthorized();
        }
    }
}

