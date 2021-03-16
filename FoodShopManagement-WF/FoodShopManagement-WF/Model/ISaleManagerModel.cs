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
        List<ProductModel> loadProductsList();
        List<TblCategoryDTO> loadCategoryList();
        List<ProductModel> searchProduct(SearchProductModel model);
    }
}
