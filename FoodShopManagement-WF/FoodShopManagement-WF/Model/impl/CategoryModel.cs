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
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("category/loadCategory", Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var listFromAPI= responseMessage.Content.ReadAsStringAsync();
                List<TblCategoryDTO> listResult = JsonConvert.DeserializeObject<List<TblCategoryDTO>>(listFromAPI.Result);
                return listResult;
            }
            return null;
        }
    }
}
