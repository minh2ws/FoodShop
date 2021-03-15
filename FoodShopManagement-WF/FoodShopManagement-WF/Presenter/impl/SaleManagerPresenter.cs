using DTO;
using DTO.Model;
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
        ISaleManagerModel saleManagerModel = new SaleManagerModel();
        public List<TblCategoryDTO> GetCategories()
        {
            List<TblCategoryDTO> listCategory = saleManagerModel.loadCategoryList();
            return listCategory;
        }

        public List<TblProductsDTO> GetProducts()
        {
            List<TblProductsDTO> listProducts = saleManagerModel.loadProductsList();
            return listProducts;
        }

        public List<TblProductsDTO> searchProduct(frmSaleManager_V2 form)
        {
            SearchProductModel model = new SearchProductModel
            {
                categoryName = form.getCategoryName(),
                productName = form.getProductName(),
            };

            List<TblProductsDTO> searchResult = saleManagerModel.searchProduct(model);
            return searchResult;
        }
    }
}
