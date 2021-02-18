using FoodShopManagementApi.DAO;
using FoodShopManagementApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult CheckLogin([FromBody]TblEmployeesDTO tblEmployeeDTO)
        {
            TblEmployeesDAO dao = new TblEmployeesDAO();
            try
            {
                TblEmployeesDTO dto = dao.CheckLogin(tblEmployeeDTO.idEmployee, tblEmployeeDTO.password);
                if (dto != null) return Ok(dto);
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
