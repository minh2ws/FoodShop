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
    class CategoryModel : ICategoryModel
    {
        public List<TblCategoryDTO> getAll()
        {
            try
            {
                HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("category/loadCategory", Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var listFromAPI = responseMessage.Content.ReadAsStringAsync();
                    List<TblCategoryDTO> listResult = JsonConvert.DeserializeObject<List<TblCategoryDTO>>(listFromAPI.Result);
                    return listResult;
                }
                return null;
            }catch(Exception e)
            {
                throw e;
            }
           
        }
        public bool updateCategory(TblCategoryDTO categoryDTO)
        {
            try
            {
                HttpResponseMessage responseMessage = ApiConnection.loadPutJsonObject("category/updateCategory",categoryDTO, Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public bool addCategory(TblCategoryDTO categoryDTO)
        {
            try
            {
                HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("category/addCategory", categoryDTO, Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
