using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using FoodShopManagement_WF.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter.impl
{
    class SaleManagerPresenter : ISaleManagerPresenter
    {
        private IProductModel productModel = new ProductModel();
        private ICategoryModel categoryModel = new CategoryModel();
        private ICustomerModel customerModel = new CustomerModel();
        private frmSaleManager_V2 form;

        public SaleManagerPresenter()
        {
        }

        public SaleManagerPresenter(frmSaleManager_V2 form)
        {
            this.form = form;
        }

        public List<TblCategoryDTO> GetCategories()
        {
            List<TblCategoryDTO> listCategory = categoryModel.getAll();
            return listCategory;
        }

        public List<TblProductsDTO> GetProducts()
        {
            List<TblProductsDTO> listProducts = productModel.getAll();
            return listProducts;
        }

        public List<TblProductsDTO> searchProduct(frmSaleManager_V2 form)
        {
            List<TblProductsDTO> searchResult = productModel.searchProduct(form.getCategoryName(),form.getProductName());
            return searchResult;
        }

        public DataTable GetCustomers()
        {
            List<TblCustomerDTO> listResult = customerModel.loadCustomers();
            //convert from list to datatable and return it
            return ConvertCustom.ListToDataTable<TblCustomerDTO>(listResult);
        }

        public void AddCustomer()
        {
            frmCustomerDetail customerDetail = new frmCustomerDetail(true, form);
            DialogResult r = customerDetail.ShowDialog();
        }

        public void UpdateCustomer()
        {
            frmCustomerDetail customerDetail = new frmCustomerDetail(false, form);

            //get customer detail from frmSaleManager
            customerDetail.setCustomerId(form.getCustomerId().Text);
            customerDetail.getCustomerName().Text = form.getCustomerName().Text;
            customerDetail.getCustomerPhone().Text = form.getCustomerPhone().Text;
            customerDetail.getAddress().Text = form.getCustomerAddress().Text;

            //show customerDetail form
            DialogResult r = customerDetail.ShowDialog();
        }

        private bool checkCustomerField(string cusName, string cusPhone, string cusAddress)
        {
            if (cusName.Trim().Length <= 0 || cusName.Trim().Length > 50)
            {
                MessageBox.Show(MessageUtil.INVALID_CUS_NAME);
                return false;
            }

            try
            {
                int phoneNumber = int.Parse(cusPhone);
            }
            catch (FormatException)
            {
                MessageBox.Show(MessageUtil.INVALID_CUS_PHONE);
                return false;
            }

            if (cusAddress.Trim().Length <= 0 || cusAddress.Trim().Length > 200)
            {
                MessageBox.Show(MessageUtil.INVALID_CUS_ADDRESS);
                return false;
            }
            return true;
        }
        public void SaveCustomer(frmCustomerDetail frmCustomerDetail)
        {
            try
            {
                string name = frmCustomerDetail.getCustomerName().Text;
                string phone = frmCustomerDetail.getCustomerPhone().Text;
                string address = frmCustomerDetail.getAddress().Text;
                bool isValid = checkCustomerField(name, phone, address);
                if (isValid)
                {
                    TblCustomerDTO dto = new TblCustomerDTO()
                    {
                        idCustomer = frmCustomerDetail.getCustomerID(),
                        name = name,
                        phone = phone,
                        address = address
                    };
                    if (frmCustomerDetail.isAddNew())
                    {
                        customerModel.addCustomer(dto);
                        this.form.loadCustomers();
                    }
                    else
                    {
                        customerModel.updateCustomer(dto);
                        this.form.loadCustomers();
                    }
                    MessageBox.Show(MessageUtil.SAVE_SUCCESS);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MessageUtil.ERROR + " Save Customer!");
            }
        }
    }
}
