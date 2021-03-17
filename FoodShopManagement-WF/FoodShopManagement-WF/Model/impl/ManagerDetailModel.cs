using DTO;
using DTO.Model;
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
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("employee/Insert", Employee, Program.TokenGlobal);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var employeeDTO = responseMessage.Content.ReadAsStringAsync();
                TblEmployeesDTO emp = JsonConvert.DeserializeObject<TblEmployeesDTO>(employeeDTO.Result);
                return emp;
            }
            return null;

        }

        //public List<LoadEmployeeModel> loadData(TblEmployeesDTO dto)
        //{
        //    Dictionary<String, String> role = new Dictionary<string, string>();
        //    role.Add("role", dto.role);
        //    HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("employee/Load", role, Program.TokenGlobal);
        //    if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
        //    {
        //        var loadResult = responseMessage.Content.ReadAsStringAsync();

        //        List<LoadEmployeeModel> list = JsonConvert.DeserializeObject<List<LoadEmployeeModel>>(loadResult.Result);
        //        return list;
        //    }
        //    return null;
        //}

        public List<TblEmployeesDTO> loadEmployeeDTO(TblEmployeesDTO dto)
        {
            Dictionary<String, String> role = new Dictionary<string, string>();
            role.Add("role", dto.role);
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("employee/Load", role, Program.TokenGlobal);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var loadResult = responseMessage.Content.ReadAsStringAsync();

                List<TblEmployeesDTO> list = JsonConvert.DeserializeObject<List<TblEmployeesDTO>>(loadResult.Result);
                return list;
            }
            return null;
        }

        public TblEmployeesDTO DeleteEmployee(TblEmployeesDTO dto)
        {
            Dictionary<String, String> id = new Dictionary<string, string>();
            id.Add("id", dto.idEmployee);
            HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("employee/Delete", id, Program.TokenGlobal);
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
