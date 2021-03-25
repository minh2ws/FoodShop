using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Util
{
    public class MessageUtil
    {
        public static string ERROR = "Error processing";
        public static string SAVE_SUCCESS = "Save success";
        public static string INVALID_CUS_NAME = "Customer Name must from 0 to 50 chars!!";
        public static string INVALID_CUS_PHONE = "Customer Phone must be number!!";
        public static string INVALID_CUS_ADDRESS = "Customer Address must from 0 to 200 chars";
        public static string DELETE_CONFIRM = "Do you want to delete ?";
        public static string DELETE_SUCCESS = "Delete success";
        public static string DELETE_ALREADY = "Delete Already";
        public static string CUSTOMER_INVALID = "Please choose a customer to checkout!!";
        public static string CUSTOMER_EMPTY = "Please choose a customer or create a new one!!";
        public static string CHECKOUT_SUCCESS = "checkout success!!";
        public static string ITEM_EMPTY = "Please choose product to checkout!";
    }
}
