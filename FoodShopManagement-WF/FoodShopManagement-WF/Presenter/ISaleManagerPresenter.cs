using DTO;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter
{
    interface ISaleManagerPresenter
    {
        void SearchProduct();
        void AddCustomer();
        void UpdateCustomer();
        void SaveCustomer(frmCustomerDetail form);
        void LoadProducts();
        void LoadCustomers();
        void SearchCustomer();
        void AddProductToOrder();
        void LoadProductsOrder();
        void UpdateAmount();
        void RemoveProductFromOrder();
        void CheckoutCart();
        void GetCustomerInfo();
        void UpdateQuantityOfItem();
        void UpdateCurrentAmount();
    }
}