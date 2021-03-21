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

namespace FoodShopManagementApi.DTO
{
    [Route("api/FoodShopManagement/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IConfiguration _config;

        public ProductController(IConfiguration config)
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

        [HttpGet("loadProducts")]
        [Produces("application/json")]
        public IActionResult LoadProducts()
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    List<TblProductsDTO> listProduct = dao.findAll();
                    if (listProduct != null)
                    {
                        return Ok(listProduct);
                    }
                }
                catch (Exception)
                {
                   return StatusCode(500);
                }
            }
            return Unauthorized();
        }

        [HttpGet("searchProduct")]
        [Produces("application/json")]
        public IActionResult SearchProduct([FromQuery(Name ="name")] string name, [FromQuery(Name ="category")] string category)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    if (name == null)
                    {
                        name = "";
                    }
                    if (category == null)
                    {
                        category = "";
                    }
                    List<TblProductsDTO> result = dao.searchProduct(category, name);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                }
                catch (Exception)
                {
                   return StatusCode(500);
                }
            }
            return Unauthorized();
        }
        [HttpPost("addProduct")]
        [Produces("application/json")]
        public IActionResult addProduct([FromBody] TblProductsDTO tblProductsDTO)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    if (dao.addProduct(tblProductsDTO))
                    {
                        return Ok(tblProductsDTO);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception)
                {
                   return StatusCode(500);
                }
            }
            return Unauthorized();
        }
        [HttpPut("updateProduct")]
        [Produces("application/json")]
        public IActionResult updateProduct([FromBody] TblProductsDTO tblProductsDTO)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    if (dao.updateProduct(tblProductsDTO))
                    {
                        return Ok(tblProductsDTO);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception e)
                {
                  return StatusCode(500);
                }
            }
            return Unauthorized();
        }
        [HttpPut("updateStatus")]
        [Produces("application/json")]
        public IActionResult updateStatusProduct([FromBody] TblProductsDTO tblProductsDTO)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    if (dao.updateStatusProduct(tblProductsDTO))
                    {
                        return Ok(tblProductsDTO);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(500);
                }
            }
            return Unauthorized();
        }
    }
}
