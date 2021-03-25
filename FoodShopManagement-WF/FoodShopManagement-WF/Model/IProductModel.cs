using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model
{
    interface IProductModel
    {
        List<TblProductsDTO> getProducts();
        List<TblProductsDTO> searchProduct(string categoryName, string productName);
        bool updateProduct(TblProductsDTO dto);
        bool addProduct(TblProductsDTO dto);
        bool setStatusProduct(TblProductsDTO dto);
        List<TblProductsDTO> getProductsToSale();
        TblProductsDTO getProduct(string idProduct);
    }
}
