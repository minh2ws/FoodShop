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
                    sqlDataReader= sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    List<TblProductsDTO> result = new List<TblProductsDTO>();
                    while (sqlDataReader.Read())
                    {
                        TblProductsDTO product = new TblProductsDTO();
                        product.name=sqlDataReader.GetString("name");
                        product.name = sqlDataReader.GetString("idProduct");
                        product.price = sqlDataReader.GetFloat("price");
                        product.quantity = sqlDataReader.GetInt32("quantity");
                        product.idCategory = sqlDataReader.GetString("idCategory");
                        product.status = sqlDataReader.GetBoolean("status");
                        result.Add(product);
                    }
                    return result;
                }
            }catch(Exception e)
            {
                throw e;
            }
            finally
            {
                try
                {
                    DBUtil.CloseConnection(sqlDataReader, sqlConnection);
                }catch(Exception ex)
                {
                    throw ex;
                }
                
            }
            return null;
        }
    }
}
