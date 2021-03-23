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
        void searchProduct();
        void AddCustomer();
        void UpdateCustomer();
        void SaveCustomer(frmCustomerDetail form);
        void LoadProducts();
        void LoadCustomers();
        void SearchCustomer();
    }
}