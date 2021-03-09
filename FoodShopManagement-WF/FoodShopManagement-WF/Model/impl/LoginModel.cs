using FoodShopManagement_WF.DTO;
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
    class LoginModel : ILoginModel
    {
        public TblEmployeesDTO checkLogin(TblEmployeesDTO tblEmployeeDTO)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("login", tblEmployeeDTO);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var employeeDTO = responseMessage.Content.ReadAsStringAsync();
                TblEmployeesDTO emp = JsonConvert.DeserializeObject<TblEmployeesDTO>(employeeDTO.Result);
                return emp;
            }
            return null;
            
        }
    }
}
