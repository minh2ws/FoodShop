using DTO;
using FoodShopManagement_WF.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model.impl
{
    public class ProductModel : IProductModel
    {
        public ProductModel()
        {

        }

       
        public List<TblProductsDTO> getProducts()
        {
            try
            {
                HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("product/loadProducts", Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var listFromAPI = responseMessage.Content.ReadAsStringAsync();
                    List<TblProductsDTO> listResult = JsonConvert.DeserializeObject<List<TblProductsDTO>>(listFromAPI.Result);
                    return listResult;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<TblProductsDTO> searchProduct(string categoryName,string productName)
        {
            Dictionary<string, string> hashParam = new Dictionary<string, string>();
            hashParam.Add("category", categoryName);
            hashParam.Add("name", productName);
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("product/searchProduct", hashParam, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                //get json content
                var searchResult = responseMessage.Content.ReadAsStringAsync();
                //convert json to list
                List<TblProductsDTO> listResult = JsonConvert.DeserializeObject<List<TblProductsDTO>>(searchResult.Result);
                return listResult;
            }
            return null;
        }

        public bool updateProduct(TblProductsDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPutJsonObject("product/updateProduct", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
        public bool addProduct(TblProductsDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("product/addProduct", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool setStatusProduct(TblProductsDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPutJsonObject("product/updateStatus", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public List<TblProductsDTO> getProductsToSale()
        {
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("product/load-products-to-sale", Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var listFromAPI = responseMessage.Content.ReadAsStringAsync();
                List<TblProductsDTO> listProducts = JsonConvert.DeserializeObject<List<TblProductsDTO>>(listFromAPI.Result);
                return listProducts;
            }
            return null;
        }

        public TblProductsDTO getProduct(string idProduct)
        {
            try
            {
                Dictionary<string, string> hashParam = new Dictionary<string, string>();
                hashParam.Add("idProduct", idProduct);
                HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("product/getProduct", hashParam, Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var product = responseMessage.Content.ReadAsStringAsync();
                    TblProductsDTO productDTO = JsonConvert.DeserializeObject<TblProductsDTO>(product.Result);
                    return productDTO;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
