using DTO;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter
{
    interface IWarehousePresenter
    {
        void getAllCategory();
        void saveCategory(frmCategoryDetail frmCategoryDetail);
        void editCategory();
        void addCategory();
        void searchCategory();
        void getAllProduct();
        void searchProductName();
    }
}
