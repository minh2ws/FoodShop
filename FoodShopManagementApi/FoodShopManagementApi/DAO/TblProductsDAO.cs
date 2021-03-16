using DTO;
using DTO.Model;
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
            if (instance == null)
            {
                instance = new TblProductsDAO();
            }
            return instance;
        }

        private SqlConnection sqlConnection = null;
        private SqlDataReader sqlDataReader = null;

        SqlCommand sqlCommand = null;
        public List<ProductModel> findAll()
        {

            string sql = "select idProduct,name,price,quantity from tblProducts";
            try
            {
                sqlConnection = DBUtil.MakeConnect();
                if (sqlConnection != null)
                {
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    List<ProductModel> result = new List<ProductModel>();
                    while (sqlDataReader.Read())
                    {
                        ProductModel product = new ProductModel();
                        product.ProductId = sqlDataReader["idProduct"].ToString();
                        product.Name = sqlDataReader["name"].ToString();
                        product.Price = float.Parse(sqlDataReader["price"].ToString());
                        product.Quantity = int.Parse(sqlDataReader["quantity"].ToString());

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

        public List<ProductModel> searchProduct(string category, string searchValue)
        {
            string sql = "SELECT idProduct, p.name, price, quantity "
                    + "FROM tblProducts p, tblCategory c "
                    + "WHERE p.idCategory = c.idCategory ";

            //check category field to create sql string
            if (category.Trim().Length != 0 && category != null)
            {
                sql += "AND c.name = '" + category + "' ";
            }

            //check search value field to create sql string
            if (searchValue.Trim().Length != 0 && searchValue != null)
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
                    List<ProductModel> result = new List<ProductModel>();
                    while (sqlDataReader.Read())
                    {
                        ProductModel product = new ProductModel();
                        product.ProductId = sqlDataReader["idProduct"].ToString();
                        product.Name = sqlDataReader["name"].ToString();
                        product.Price = float.Parse(sqlDataReader["price"].ToString());
                        product.Quantity = int.Parse(sqlDataReader["quantity"].ToString());

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
