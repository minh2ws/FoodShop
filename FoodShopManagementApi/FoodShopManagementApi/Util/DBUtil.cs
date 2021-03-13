using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace FoodShopManagementApi.Util
{
    public class DBUtil
    {
        public static SqlConnection MakeConnect()
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
                stringBuilder.UserID = "admin";
                stringBuilder.Password = "12345678";
                stringBuilder.InitialCatalog = "TheFoodHouse";
                stringBuilder.DataSource = @"foodshopmanagement.cfxet315umch.ap-southeast-1.rds.amazonaws.com,1433";
                stringBuilder.ConnectTimeout = 5;

                cn.ConnectionString = stringBuilder.ConnectionString;
                if (cn.State == System.Data.ConnectionState.Closed)
                {
                    cn.Open();
                }
                return cn;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
        public static void CloseConnection(SqlDataReader sqlDataReader, SqlConnection sqlConnection)
        {
            try
            {
                if (sqlDataReader != null)
                {
                    sqlDataReader.Close();
                }
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
            catch (SqlException e) { Console.WriteLine(e.Message); }
        }
    }
    
}
