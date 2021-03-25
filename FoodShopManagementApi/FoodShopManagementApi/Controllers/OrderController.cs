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
    [Route("api/FoodShopManagement/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IConfiguration _config;

        public OrderController(IConfiguration config)
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

        [HttpPost("add-order")]
        [Produces("application/json")]
        public IActionResult addOrder([FromBody] TblOrderDTO order)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblOrderDAO dao = TblOrderDAO.getInstance();
                try
                {
                    if (dao.AddOrder(order))
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

        [HttpPost("add-order-detail")]
        [Produces("application/json")]
        public IActionResult addOrderDetail([FromBody] CartDTO dto)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblOrderDetailDAO dao = TblOrderDetailDAO.getInstance();
                try
                {
                    if (dao.AddOrderDetail(dto))
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

        [HttpPost("load-total")]
        [Produces("application/json")]
        public IActionResult LoadTotal([FromBody] DateTime date)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblOrderDAO dao = TblOrderDAO.getInstance();
                try
                {
                    float result = dao.SelectTotalOrder(date);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else return BadRequest();
                }
                catch (Exception)
                {
                    StatusCode(500);
                }
            }
            return Unauthorized();
        }
        [HttpPost("load-listOrderdetail")]
        [Produces("application/json")]
        public IActionResult LoadlistOrderdetail([FromBody] DateTime date)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblOrderDetailDAO dao = TblOrderDetailDAO.getInstance();
                try
                {
                    List<RevenuesDTO> result = dao.SelectOrderDetail(date);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else return BadRequest();
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
