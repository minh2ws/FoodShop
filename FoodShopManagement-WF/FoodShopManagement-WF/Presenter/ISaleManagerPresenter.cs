using DTO;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter
{
    interface ISaleManagerPresenter
    {
        List<TblProductsDTO> GetProducts();
        List<TblCategoryDTO> GetCategories();
        List<TblProductsDTO> searchProduct(frmSaleManager_V2 form);
        DataTable GetCustomers();
        void AddCustomer();
        void UpdateCustomer();
        void SaveCustomer(frmCustomerDetail form);
    }
}