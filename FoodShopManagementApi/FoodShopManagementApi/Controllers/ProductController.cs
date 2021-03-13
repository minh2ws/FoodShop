using DTO;
using FoodShopManagementApi.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.DTO
{
    [Route("api/FoodShopManagement")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("loadProducts")]
        [Produces("application/json")]
        public IActionResult LoadProducts()
        {
            TblProductsDAO dao = new TblProductsDAO();
            try
            {
                List<TblProductsDTO> listProduct = dao.findAll();
                if (listProduct != null)
                {
                    return Ok(listProduct);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return Unauthorized();
        }
    }
}
