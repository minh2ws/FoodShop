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
    [Route("api/FoodShopManagement/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IConfiguration _config;

        public CategoryController(IConfiguration congig)
        {
            _config = congig;
        }

        public bool ValidateToken()
        {
            //doc header cua request
            var header = HttpContext.Request.Headers;
            header.TryGetValue("Authorization", out Microsoft.Extensions.Primitives.StringValues value);
            bool isValid = JwtUtil.ValidateJSONWebToken(value, _config);
            return isValid;
        }

        [HttpGet("loadCategory")]
        [Produces("application/json")]
        public IActionResult loadCategory()
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblCategoryDAO dao = new TblCategoryDAO();
                try
                {
                    List<TblCategoryDTO> listCategory = dao.loadCategory();
                    if (listCategory != null)
                    {
                        return Ok(listCategory);
                    }
                }
                catch (Exception)
                {
                    StatusCode(500);
                }
            }
            return Unauthorized();
        }
        [HttpPost("addCategory")]
        [Produces("application/json")]
        public IActionResult addCategory([FromBody] TblCategoryDTO categoryDTO)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblCategoryDAO dao = new TblCategoryDAO();
                try
                {
                    if (dao.add(categoryDTO))
                    {
                        return Ok(categoryDTO);
                    }
                }
                catch(Exception)
                {
                   return StatusCode(500);
                }
            }
            return Unauthorized();
        }
        [HttpPut("updateCategory")]
        [Produces("application/json")]
        public IActionResult updateCategory([FromBody] TblCategoryDTO categoryDTO)
        {
            bool isValidToken = ValidateToken();
            if (isValidToken)
            {
                TblCategoryDAO dao = new TblCategoryDAO();
                try
                {
                    if (dao.update(categoryDTO))
                    {
                        return Ok(categoryDTO);
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
