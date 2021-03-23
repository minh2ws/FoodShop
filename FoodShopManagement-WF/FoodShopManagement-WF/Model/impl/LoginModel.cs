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
    class LoginModel : ILoginModel
    {
        public TblEmployeesDTO checkLogin(TblEmployeesDTO tblEmployeeDTO)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObjectLogin("login", tblEmployeeDTO);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var employeeDTO = responseMessage.Content.ReadAsStringAsync();
                IEnumerable<string> token = responseMessage.Headers.GetValues("token");
                Program.TokenGlobal = token.FirstOrDefault();
                TblEmployeesDTO emp = JsonConvert.DeserializeObject<TblEmployeesDTO>(employeeDTO.Result);
                return emp;
            }
            return null;
        }
       
    }
}
