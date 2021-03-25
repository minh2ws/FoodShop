using DTO;
using FoodShopManagementApi.DAO;
using FoodShopManagementApi.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                    Claim idEmployeeClaim= getClaims()[0];
                    if (dao.addProduct(tblProductsDTO, idEmployeeClaim.Value))
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
                    Claim idEmployeeClaim = getClaims()[0];
                    if (dao.updateProduct(tblProductsDTO, idEmployeeClaim.Value))
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
                Claim idEmployeeClaim = getClaims()[0];
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    if (dao.updateStatusProduct(tblProductsDTO, idEmployeeClaim.Value))
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
        private List<Claim> getClaims()
        {
            var header = HttpContext.Request.Headers;//doc header cua request
            header.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value);
            ClaimsPrincipal claims= JwtUtil.getClaims(value, _config);
            ClaimsIdentity identity = (ClaimsIdentity)claims.Identity;
            return identity.Claims.ToList();
        }

        [HttpGet("load-products-to-sale")]
        [Produces("application/json")]
        public IActionResult LoadProductsToSale()
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    List<TblProductsDTO> listProduct = dao.loadProductToSale();
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

        [HttpGet("getProduct")]
        [Produces("application/json")]
        public IActionResult getProduct([FromQuery(Name = "idProduct")] string idProduct)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                Claim idEmployeeClaim = getClaims()[0];
                TblProductsDAO dao = TblProductsDAO.getInstance();
                try
                {
                    TblProductsDTO dto = dao.getProduct(idProduct);
                    if (dto != null)
                    {
                        return Ok(dto);
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
