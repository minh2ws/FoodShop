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
        private BindingSource bsProduct;
        private BindingSource bsCustomer;

        public SaleManagerPresenter() { }

        public SaleManagerPresenter(frmSaleManager_V2 form)
        {
            this.form = form;
        }

        public void searchProduct()
        {
            string categoryName = form.getCmbCategory().Text;
            string productName = form.getProductName().Text;
            List<TblProductsDTO> searchResult = productModel.searchProduct(categoryName, productName);

            bsProduct.DataSource = searchResult;

            //binding data
            form.getDgvProduct().DataSource = bsProduct;
            form.getBnProduct().BindingSource = bsProduct;
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
                        LoadCustomers();
                    }
                    else
                    {
                        customerModel.updateCustomer(dto);
                        LoadCustomers();
                    }
                    MessageBox.Show(MessageUtil.SAVE_SUCCESS);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MessageUtil.ERROR + " Save Customer!");
            }
        }

        public void LoadProducts()
        {
            List<TblProductsDTO> listProducts = productModel.getProducts();
            DataTable dtProduct = ConvertCustom.ListToDataTable<TblProductsDTO>(listProducts);
            bsProduct = new BindingSource()
            {
                DataSource = dtProduct
            };

            //binding data to data grid view
            form.getBnProduct().BindingSource = bsProduct;
            form.getDgvProduct().DataSource = bsProduct;

            //hide unessesary column
            form.getDgvProduct().Columns["idProduct"].Visible = false;
            form.getDgvProduct().Columns["status"].Visible = false;
            form.getDgvProduct().Columns["idCategory"].Visible = false;
            form.getDgvProduct().Columns["categoryName"].Visible = false;

            List<TblCategoryDTO> listCategory = categoryModel.getAll();
            foreach (var category in listCategory)
            {
                form.getCmbCategory().Items.Add(category.name);
            }
        }

        public void LoadCustomers()
        {
            List<TblCustomerDTO> listCustomers = customerModel.getCustomers();
            DataTable dtCustomer = ConvertCustom.ListToDataTable<TblCustomerDTO>(listCustomers);
            bsCustomer = new BindingSource()
            {
                DataSource = dtCustomer
            };

            //binding data to data grid view
            form.getBnCustomer().BindingSource = bsCustomer;
            form.getDgvCustomer().DataSource = bsCustomer;

            //hide unnecessary column
            form.getDgvCustomer().Columns["phone"].Visible = false;
            form.getDgvCustomer().Columns["address"].Visible = false;
            form.getDgvCustomer().Columns["point"].Visible = false;

            //clear and add new data binding
            clearDataBindingTextCustomer();
            bindingDataTextCustomer();
        }

        public void clearDataBindingTextCustomer()
        {
            form.getCustomerId().DataBindings.Clear();
            form.getCustomerName().DataBindings.Clear();
            form.getCustomerPhone().DataBindings.Clear();
            form.getCustomerAddress().DataBindings.Clear();
            form.getCustomerPoint().DataBindings.Clear();
        }

        public void bindingDataTextCustomer()
        {
            form.getCustomerId().DataBindings.Add("Text", bsCustomer, "idCustomer");
            form.getCustomerName().DataBindings.Add("Text", bsCustomer, "name");
            form.getCustomerPhone().DataBindings.Add("Text", bsCustomer, "phone");
            form.getCustomerAddress().DataBindings.Add("Text", bsCustomer, "address");
            form.getCustomerPoint().DataBindings.Add("Text", bsCustomer, "point");
        }

        public void SearchCustomer()
        {
            string searchValue = form.getSearchCustomer().Text;
            if (searchValue.Equals(""))
            {
                bsCustomer.Filter = "";
            }
            else
            {
                bsCustomer.Filter = "name like '%" + searchValue + "%'";
            }
        }
    }
}
