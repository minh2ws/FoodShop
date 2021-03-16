using DTO;
using DTO.Model;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter
{
    interface ISaleManagerPresenter
    {
        List<ProductModel> GetProducts();
        List<TblCategoryDTO> GetCategories();
        List<ProductModel> searchProduct(frmSaleManager_V2 form);
    }
}