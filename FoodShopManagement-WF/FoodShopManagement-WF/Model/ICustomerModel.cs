using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model
{
    interface ICustomerModel
    {
        List<TblCustomerDTO> getCustomers();
        bool addCustomer(TblCustomerDTO dto);
        bool updateCustomer(TblCustomerDTO dto);
        bool updatePoint(TblCustomerDTO dto);
    }
}
