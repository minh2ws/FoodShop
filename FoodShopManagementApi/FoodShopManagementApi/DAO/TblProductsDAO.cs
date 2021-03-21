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
            if (instance == null)
            {
                instance = new TblProductsDAO();
            }
            return instance;
        }

        private SqlConnection sqlConnection = null;
        private SqlDataReader sqlDataReader = null;

        SqlCommand sqlCommand = null;
        public List<TblProductsDTO> findAll()
        {

            string sql = "select p.idProduct,p.name,p.price,p.quantity,p.status,p.idCategory,c.name as categoryName from tblProducts p,tblCategory c where p.idCategory=c.idCategory";
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
                        product.categoryName = sqlDataReader["categoryName"].ToString();
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
            string sql = "SELECT p.idProduct, p.name, p.price, p.quantity,p.status,p.idCategory, c.name as categoryName "
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
                        product.categoryName = sqlDataReader["categoryName"].ToString();
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
        public bool addProduct(TblProductsDTO dto)
        {
            string sql = "insert into tblProducts() values(@)";
            sqlConnection = DBUtil.MakeConnect();
            try
            {
                if (sqlConnection != null)
                {
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("", dto.idCategory);
                    sqlCommand.Parameters.AddWithValue("", dto.idProduct);
                    sqlCommand.Parameters.AddWithValue("", dto.name);
                    sqlCommand.Parameters.AddWithValue("", dto.price);
                    sqlCommand.Parameters.AddWithValue("", dto.quantity);
                    sqlCommand.Parameters.AddWithValue("", dto.status);
                    return sqlCommand.ExecuteNonQuery() > 0;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DBUtil.CloseConnection(null, sqlConnection);
            }
        }
        public bool updateProduct(TblProductsDTO dto)
        {
            string sql = "UPDATE tblProducts " +
                "SET name=@name, price=@price, quantity=@quantity, status=@status, idCategory=@idCategory " +
                "WHERE idProduct=@idProduct";
            try
            {
                sqlConnection = DBUtil.MakeConnect();
                if (sqlConnection != null)
                {
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@name", dto.name);
                    sqlCommand.Parameters.AddWithValue("@price", dto.price);
                    sqlCommand.Parameters.AddWithValue("@quantity", dto.quantity);
                    sqlCommand.Parameters.AddWithValue("@status", dto.status);
                    sqlCommand.Parameters.AddWithValue("@idCategory", dto.idCategory);

                    return sqlCommand.ExecuteNonQuery() > 0;
                }
            }catch(SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(null, sqlConnection);
            }
            return false;
        }
    }
}
