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
    class EmployeeModel : IEmployeeModel
    {
        public bool InsertEmployee(TblEmployeesDTO Employee)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("employee/Insert", Employee, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var employeeDTO = responseMessage.Content.ReadAsStringAsync();
                bool result = JsonConvert.DeserializeObject<bool>(employeeDTO.Result);
                return result;
            }
            return false ;

        }

        public bool UpdateEmployee(TblEmployeesDTO Employee)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("employee/UpdateEmployee", Employee, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var employeeDTO = responseMessage.Content.ReadAsStringAsync();
                bool result = JsonConvert.DeserializeObject<bool>(employeeDTO.Result);
                return result;
            }
            return false;

        }

        public List<TblEmployeesDTO> getAll()
        {
            try
            {
                HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("employee/Load", Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var listFromAPI = responseMessage.Content.ReadAsStringAsync();
                    List<TblEmployeesDTO> listResult = JsonConvert.DeserializeObject<List<TblEmployeesDTO>>(listFromAPI.Result);
                    return listResult;
                }
                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
     
        public List<TblEmployeesDTO> LoadEmpByRole(string role)
        {
            Dictionary<string, string> hashParam = new Dictionary<string, string>();
            hashParam.Add("role", role);
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("employee/LoadByRole", hashParam, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var loadResult = responseMessage.Content.ReadAsStringAsync();

                List<TblEmployeesDTO> list = JsonConvert.DeserializeObject<List<TblEmployeesDTO>>(loadResult.Result);
                return list;
            }
            return null;
        }

        public Boolean DeleteEmployee(string id)
        {
            Dictionary<String, String> hashParam = new Dictionary<string, string>();
            hashParam.Add("id", id);
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("employee/Delete", hashParam, Program.TokenGlobal);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var result = responseMessage.Content.ReadAsStringAsync();
                bool emp = JsonConvert.DeserializeObject<bool>(result.Result);
                return emp;
            }
            return false;
        }

        public bool UpdateEmpDetail(TblEmployeesDTO emp)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("employee/UpdateEmpDetail", emp, Program.TokenGlobal);
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
