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
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter.impl
{
    class SaleManagerPresenter : ISaleManagerPresenter
    {
        IProductModel productModel = new ProductModel();
        ICategoryModel categoryModel = new CategoryModel();
        ICustomerModel customerModel = new CustomerModel();
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
    }
}
