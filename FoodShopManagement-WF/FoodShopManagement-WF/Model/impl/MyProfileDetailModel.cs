using DTO;
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
    class MyProfileDetailModel : IMyProfileDetailModel
    {
        public bool UpdateEmpDetail(TblEmployeesDTO model)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("employee/UpdateEmpDetail",model, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                //get json content
                var body = responseMessage.Content.ReadAsStringAsync();
                bool result = JsonConvert.DeserializeObject<bool>(body.Result);
                return result;
            }
            return false;
        }
    }
}
