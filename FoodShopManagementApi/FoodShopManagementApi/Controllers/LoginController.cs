using DTO;
using FoodShopManagementApi.DAO;
using FoodShopManagementApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [HttpPost("login")]
        [Produces("application/json")]
        public IActionResult CheckLogin([FromBody]TblEmployeesDTO tblEmployeeDTO)
        {
            TblEmployeesDAO dao = new TblEmployeesDAO();
            IActionResult response = Unauthorized();
            try
            {
                TblEmployeesDTO dto = dao.CheckLogin(tblEmployeeDTO.idEmployee, tblEmployeeDTO.password);
                if (dto != null)
                {
                    string token = JwtUtil.GenerateJSONWebToken(dto,_config);
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
