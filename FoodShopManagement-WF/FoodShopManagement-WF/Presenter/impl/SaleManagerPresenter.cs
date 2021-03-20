using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter.impl
{
    class SaleManagerPresenter : ISaleManagerPresenter
    {
        IProductModel productModel = new ProductModel();
        ICategoryModel categoryModel = new CategoryModel();
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
    }
}
