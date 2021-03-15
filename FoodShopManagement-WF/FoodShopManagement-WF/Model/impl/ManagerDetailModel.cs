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
    class ManagerDetailModel : IManagerDetailModel
    {
        public TblEmployeesDTO InsertEmployee(TblEmployeesDTO Employee)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("Employee/Insert", Employee);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var result = responseMessage.Content.ReadAsStringAsync();
                bool emp = JsonConvert.DeserializeObject<Boolean>(result.Result);

            }
            return null;

        }
    }
}
