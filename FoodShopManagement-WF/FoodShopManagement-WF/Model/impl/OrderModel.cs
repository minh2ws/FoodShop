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
    public class OrderModel : IOrderModel
    {
        public bool AddOrder(TblOrderDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("order/add-order", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool AddOrderDetail(CartDTO dto)
        {
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("order/add-order-detail", dto, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

       
        public List<RevenuesDTO> LoadOrderDetail(DateTime date)
        {
          
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("order/load-listOrderdetail", date, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var loadResult = responseMessage.Content.ReadAsStringAsync();

                List<RevenuesDTO> list = JsonConvert.DeserializeObject<List<RevenuesDTO>>(loadResult.Result);
                return list;
            }
            return null;
        }

        public float LoadTotal(DateTime date)
        {
           
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("order/load-total", date, Program.TokenGlobal);
            if (responseMessage.IsSuccessStatusCode)
            {
                var loadResult = responseMessage.Content.ReadAsStringAsync();
                if ( loadResult.Result!="")
                {
                    float total = JsonConvert.DeserializeObject<float>(loadResult.Result);
                    return total;
                }
                
            }
            return 0;
        }
    }
}
