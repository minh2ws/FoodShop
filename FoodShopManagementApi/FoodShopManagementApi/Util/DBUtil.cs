using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace FoodShopManagementApi.Util
{
    public class DBUtil
    {
        public static SqlDataReader myDataReader = null;
        public static SqlConnection MakeConnect()
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
                stringBuilder.UserID = "sa";
                stringBuilder.Password = "Goboi123";
                stringBuilder.InitialCatalog = "EmployeeManagement";
                stringBuilder.DataSource = @"localhost,1433";
                stringBuilder.ConnectTimeout = 5;

                cn.ConnectionString = stringBuilder.ConnectionString;
                cn.Open();
                return cn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
