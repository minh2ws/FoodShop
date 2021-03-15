using DTO;
using DTO.Model;
using FoodShopManagement_WF.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model.impl
{
    class SaleManagerModel : ISaleManagerModel
    {
        public List<TblProductsDTO> loadProductsList()
        {
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("product/loadProducts", Program.TokenGlobal);
            if (responseMessage.StatusCode != HttpStatusCode.Unauthorized)
            {
                //get json content
                var listProduct = responseMessage.Content.ReadAsStringAsync();
                //convert from json to list
                List<TblProductsDTO> model = JsonConvert.DeserializeObject<List<TblProductsDTO>>(listProduct.Result);
                return model;
            }
            return null;
        }

        public List<TblCategoryDTO> loadCategoryList()
        {
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("category/loadCategory", Program.TokenGlobal);
            if (responseMessage.StatusCode != HttpStatusCode.Unauthorized)
            {
                //get json content
                var listCategory = responseMessage.Content.ReadAsStringAsync();
                //convert from json to list
                List<TblCategoryDTO> model = JsonConvert.DeserializeObject<List<TblCategoryDTO>>(listCategory.Result);
                return model;
            }
            return null;
        }

        public List<TblProductsDTO> searchProduct(SearchProductModel model)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("product/searchProduct", model, Program.TokenGlobal);
            if (responseMessage.StatusCode != HttpStatusCode.Unauthorized)
            {
                //get json content
                var searchResult = responseMessage.Content.ReadAsStringAsync();
                //convert json to list
                List<TblProductsDTO> listResult = JsonConvert.DeserializeObject<List<TblProductsDTO>>(searchResult.Result);
                return listResult;
            }
            return null;
        }
    }
}
