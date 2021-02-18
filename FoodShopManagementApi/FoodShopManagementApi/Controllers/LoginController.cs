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
        public IActionResult checkLogin([FromBody]TblEmployeesDTO tblEmployeeDTO)
        {
            
        }
    }
}
