using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model
{
    interface IOrderModel
    {
        bool AddOrder(TblOrderDTO dto);
        bool AddOrderDetail(CartDTO dto);
        List<RevenuesDTO> LoadOrderDetail(DateTime date);
        float LoadTotal(DateTime date);
    }
}
