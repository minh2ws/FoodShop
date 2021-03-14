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
                        product.idProduct = sqlDataReader["idProduct"].ToString();
                        product.name = sqlDataReader["name"].ToString();
                        product.price = float.Parse(sqlDataReader["price"].ToString());
                        product.quantity = int.Parse(sqlDataReader["quantity"].ToString());
                        product.status = bool.Parse(sqlDataReader["status"].ToString());
                        product.idCategory = sqlDataReader["idCategory"].ToString();

                        result.Add(product);
                    }
                    return result;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
                //Console.WriteLine(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(sqlDataReader, sqlConnection);
            }
            return null;
        }
    }
}
