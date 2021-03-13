using DTO;
using FoodShopManagementApi.DTO;
using FoodShopManagementApi.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.DAO
{
    public class TblProductsDAO
    {
        private SqlConnection sqlConnection = null;
        private SqlDataReader sqlDataReader = null;

        SqlCommand sqlCommand = null;
        public List<TblProductsDTO> findAll()
        {

            string sql = "select idProduct,name,price,quantity,status,idCategory from tblProducts";
            try
            {
                sqlConnection = DBUtil.MakeConnect();
                if (sqlConnection != null)
                {
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    List<TblProductsDTO> result = new List<TblProductsDTO>();
                    while (sqlDataReader.Read())
                    {
                        TblProductsDTO product = new TblProductsDTO();
                        product.idProduct = sqlDataReader.GetString("idProduct");
                        product.name = sqlDataReader.GetString("name");
                        product.price = sqlDataReader.GetFloat("price");
                        product.quantity = sqlDataReader.GetInt32("quantity");
                        product.status = sqlDataReader.GetBoolean("status");
                        product.idCategory = sqlDataReader.GetString("idCategory");
                        result.Add(product);
                    }
                    return result;
                }
            }
            catch (SqlException e)
            {
                //throw new Exception(e.Message);
                Console.WriteLine(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(sqlDataReader, sqlConnection);
            }
            return null;
        }
    }
}
