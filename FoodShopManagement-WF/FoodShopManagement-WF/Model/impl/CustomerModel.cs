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
    public class CustomerModel : ICustomerModel
    {
        public List<TblCustomerDTO> getCustomers()
        {
            try
            {
                HttpResponseMessage responseMessage = ApiConnection.loadGetJsonObject("customer/load-customer", Program.TokenGlobal);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var resultFromApi = responseMessage.Content.ReadAsStringAsync();
                    List<TblCustomerDTO> listResult = JsonConvert.DeserializeObject<List<TblCustomerDTO>>(resultFromApi.Result);
                    return listResult;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public bool addCustomer(TblCustomerDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("customer/add-customer", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var resultFromApi = responseMessage.Content.ReadAsStringAsync();
                bool isSuccess = JsonConvert.DeserializeObject<bool>(resultFromApi.Result);
                return isSuccess;
            }
            return false;
        }

        public bool updateCustomer(TblCustomerDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPutJsonObject("customer/update-customer", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var resultFromApi = responseMessage.Content.ReadAsStringAsync();
                bool isSuccess = JsonConvert.DeserializeObject<bool>(resultFromApi.Result);
                return isSuccess;
            }
            return false;
        }
        public bool UpdateEmpDetail(TblEmployeesDTO model)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("employee/UpdateEmpDetail", model, Program.TokenGlobal);
            if (responseMessage.StatusCode != HttpStatusCode.Unauthorized)
            {
                //get json content
                var body = responseMessage.Content.ReadAsStringAsync();
                bool result = JsonConvert.DeserializeObject<bool>(body.Result);
                return result;
            }
            return false;
        }

        public bool updatePoint(TblCustomerDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPutJsonObject("customer/update-point", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
