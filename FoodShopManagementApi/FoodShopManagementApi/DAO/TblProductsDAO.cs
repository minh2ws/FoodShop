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
        //Using SINGLETON pattern
        private static TblProductsDAO instance = null;

        //default constructor with private access
        private TblProductsDAO() { }

        public static TblProductsDAO getInstance()
        {
            if (TblProductsDAO.instance == null)
            {
                TblProductsDAO.instance = new TblProductsDAO();
            }
            return TblProductsDAO.instance;
        }

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
            }
            finally
            {
                DBUtil.CloseConnection(sqlDataReader, sqlConnection);
            }
            return null;
        }

        public List<TblProductsDTO> searchProduct(string category, string searchValue)
        {
            string sql = "SELECT idProduct, p.name, price, quantity, status, c.idCategory "
                    + "FROM tblProducts p, tblCategory c "
                    + "WHERE p.idCategory = c.idCategory ";

            //check category field to create sql string
            if (category.Trim().Length != 0)
            {
                sql += "AND c.name = '" + category + "' ";
            }

            //check search value field to create sql string
            if (searchValue.Trim().Length != 0)
            {
                sql += "AND p.name like '%" + searchValue + "%' ";
            }

            try
            {
                sqlConnection = DBUtil.MakeConnect();
                if (sqlConnection != null)
                {
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader();
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
            } finally
            {
                DBUtil.CloseConnection(sqlDataReader, sqlConnection);
            }
            return null;
        }
    }
}
