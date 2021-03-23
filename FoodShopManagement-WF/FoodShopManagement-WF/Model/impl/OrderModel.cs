using DTO;
using FoodShopManagement_WF.Util;
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
    }
}
