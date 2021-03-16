using DTO;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model
{
    interface ISaleManagerModel
    {
        List<TblProductsDTO> loadProductsList();
        List<TblCategoryDTO> loadCategoryList();
        List<TblProductsDTO> searchProduct(SearchProductModel model);
    }
}
