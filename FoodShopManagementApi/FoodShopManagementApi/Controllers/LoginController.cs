using DTO;
using FoodShopManagementApi.DAO;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("login")]
        [Produces("application/json")]
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
