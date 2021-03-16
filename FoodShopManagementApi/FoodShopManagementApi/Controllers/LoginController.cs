using DTO;
using FoodShopManagementApi.DAO;
using FoodShopManagementApi.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;

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

        [HttpGet("test")]
        [Produces("application/json")]
        public IActionResult test()
        {
            // api test kiểm tra validate json token 
            
            var header = HttpContext.Request.Headers;// doc header cua request
            header.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value); // lấy token authorization từ request           
            bool check = JwtUtil.ValidateJSONWebToken(value, _config);// kiem tra token
            if (check)
            {
                return Ok(true);
            }
            return Unauthorized(false);
        }



        [HttpPost("login")]
        [Produces("application/json")]
        public IActionResult CheckLogin([FromBody]TblEmployeesDTO tblEmployeeDTO)
        {
            TblEmployeesDAO dao = TblEmployeesDAO.getInstance();
            IActionResult response = Unauthorized();
            try
            {
                TblEmployeesDTO dto = dao.CheckLogin(tblEmployeeDTO.idEmployee, tblEmployeeDTO.password);
                if (dto != null)
                {
                    string token = JwtUtil.GenerateJSONWebToken(dto,_config);
                    HttpContext.Response.Headers.Add("token",token);
                    response = Ok(dto);
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
