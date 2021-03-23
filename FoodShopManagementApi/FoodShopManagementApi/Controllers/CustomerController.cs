using DTO;
using FoodShopManagementApi.DAO;
using FoodShopManagementApi.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.Controllers
{
    [Route("api/FoodShopManagement/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IConfiguration _config;

        public CustomerController(IConfiguration config)
        {
            _config = config;
        }

        public bool ValidateToken()
        {
            var header = HttpContext.Request.Headers;
            header.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value);
            bool isValid = JwtUtil.ValidateJSONWebToken(value, _config);
            return isValid;
        }

        [HttpGet("load-customer")]
        [Produces("application/json")]
        public IActionResult LoadCustomer()
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblCustomerDAO dao = TblCustomerDAO.getInstance();
                try
                {
                    List<TblCustomerDTO> result = dao.loadCustomers();
                    if (result != null)
                    {
                        return Ok(result);
                    }
                }
                catch (Exception)
                {
                    StatusCode(500);
                }
            }
            return Unauthorized();
        }

        [HttpPost("add-customer")]
        [Produces("application/json")]
        public IActionResult AddCustomer([FromBody] TblCustomerDTO dto)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblCustomerDAO dao = TblCustomerDAO.getInstance();
                try
                {
                    if (dao.AddCustomer(dto))
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {
                    StatusCode(500);
                }
            }
            return Unauthorized();
        }

        [HttpPut("update-customer")]
        [Produces("application/json")]
        public IActionResult UpdateCustomer([FromBody] TblCustomerDTO dto)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblCustomerDAO dao = TblCustomerDAO.getInstance();
                try
                {
                    bool isSuccess = dao.UpdateCustomer(dto);
                    if (isSuccess)
                    {
                        return Ok(isSuccess);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {
                    StatusCode(500);
                }
            }
            return Unauthorized();
        }

        [HttpPut("update-point")]
        [Produces("application/json")]
        public IActionResult UpdatePoint([FromBody] TblCustomerDTO dto)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblCustomerDAO dao = TblCustomerDAO.getInstance();
                try
                {
                    bool isSuccess = dao.UpdatePoint(dto);
                    if (isSuccess)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
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
