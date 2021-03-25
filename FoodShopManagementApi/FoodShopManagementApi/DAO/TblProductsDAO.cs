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
        private static readonly string STATUS_ADD = "ADD";
        private static readonly string STATUS_UPDATE = "UPDATE";
        private static readonly string STATUS_ACTIVE = "ACTIVE";
        private static readonly string STATUS_INACTIVE = "INACTIVE";

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

        public List<TblProductsDTO> loadProductToSale()
        {
            string sql = "select p.idProduct,p.name,p.price,p.quantity,p.status,p.idCategory,c.name as categoryName " +
                "from tblProducts p,tblCategory c " +
                "where p.idCategory = c.idCategory AND p.status = 1 AND p.quantity > 0 ";
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
                    + "WHERE p.idCategory = c.idCategory AND p.status = 1  AND p.quantity > 0 ";

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
        private bool writeLog(SqlCommand sqlCommand,SqlTransaction transaction, SqlConnection sqlConnection,string idProduct,string status,string idEmployee)
        {
            string logSql = "insert into tblProductLogs(idEmployee,idProduct,status,modifyDate,idLog) values(@idEmployee,@idProduct,@status,@modifyDate,@idLog)";
            try
            {
                sqlCommand = new SqlCommand(logSql, sqlConnection, transaction);
                sqlCommand.Parameters.AddWithValue("@idEmployee", idEmployee);
                sqlCommand.Parameters.AddWithValue("@idProduct", idProduct);
                sqlCommand.Parameters.AddWithValue("@status", status);
                sqlCommand.Parameters.AddWithValue("@modifyDate", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@idLog", Guid.NewGuid().ToString());
                return sqlCommand.ExecuteNonQuery()>0;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public bool addProduct(TblProductsDTO dto,string idEmployee)
        {
            
            string sql = "insert into tblProducts(idCategory,idProduct,name,price,quantity,status) values(@idCategory,@idProduct,@name,@price,@quantity,@status)";
            
            sqlConnection = DBUtil.MakeConnect();
            SqlTransaction transaction=null;
            try
            {
                if (sqlConnection != null)
                {
                    string idProduct = Guid.NewGuid().ToString();
                    transaction =sqlConnection.BeginTransaction();
                    sqlCommand = new SqlCommand(sql, sqlConnection,transaction);
                    sqlCommand.Parameters.AddWithValue("@idCategory", dto.idCategory);
                    sqlCommand.Parameters.AddWithValue("@idProduct", idProduct);
                    sqlCommand.Parameters.AddWithValue("@name", dto.name);
                    sqlCommand.Parameters.AddWithValue("@price", dto.price);
                    sqlCommand.Parameters.AddWithValue("@quantity", dto.quantity);
                    sqlCommand.Parameters.AddWithValue("@status", dto.status);
                    bool check = sqlCommand.ExecuteNonQuery()>0;
                    if (check)
                    {
                        check=writeLog(sqlCommand,transaction,sqlConnection,idProduct,STATUS_ADD, idEmployee);
                    }
                    transaction.Commit();
                    return check;
                }
                return false;
            }
            catch (Exception e)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new Exception(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(null, sqlConnection);
            }
        }
        public bool updateProduct(TblProductsDTO dto,string idEmployee)
        {
            string sql = "UPDATE tblProducts " +
                "SET name=@name, price=@price, quantity=@quantity, status=@status, idCategory=@idCategory " +
                "WHERE idProduct=@idProduct";
            SqlTransaction transaction = null;
            try
            {
                
                sqlConnection = DBUtil.MakeConnect();
                if (sqlConnection != null)
                {
                    transaction = sqlConnection.BeginTransaction();
                    sqlCommand = new SqlCommand(sql, sqlConnection,transaction);
                    sqlCommand.Parameters.AddWithValue("@name", dto.name);
                    sqlCommand.Parameters.AddWithValue("@price", dto.price);
                    sqlCommand.Parameters.AddWithValue("@quantity", dto.quantity);
                    sqlCommand.Parameters.AddWithValue("@status", dto.status);
                    sqlCommand.Parameters.AddWithValue("@idCategory", dto.idCategory);
                    sqlCommand.Parameters.AddWithValue("@idProduct", dto.idProduct);
                    bool check=sqlCommand.ExecuteNonQuery() > 0;
                    
                    if (check)
                    {
                       check= writeLog(sqlCommand, transaction, sqlConnection, dto.idProduct, STATUS_UPDATE, idEmployee);
                    }
                    transaction.Commit();
                    return check;
                }
            }catch(SqlException e)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new Exception(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(null, sqlConnection);
            }
            return false;
        }
        public bool updateStatusProduct(TblProductsDTO dto,string idEmployee)
        {
            string sql = "UPDATE tblProducts " +
                "SET status=@status " +
                "WHERE idProduct=@idProduct";
            SqlTransaction transaction = null;
            try
            {
                sqlConnection = DBUtil.MakeConnect();
                if (sqlConnection != null)
                {
                    transaction = sqlConnection.BeginTransaction();
                    sqlCommand = new SqlCommand(sql, sqlConnection,transaction);
                    sqlCommand.Parameters.AddWithValue("@status", dto.status);
                    sqlCommand.Parameters.AddWithValue("@idProduct", dto.idProduct);
                    bool check= sqlCommand.ExecuteNonQuery() > 0;
                    if (check)
                    {
                        if (dto.status)
                        {
                            check = writeLog(sqlCommand, transaction, sqlConnection, dto.idProduct, STATUS_ACTIVE, idEmployee);
                        }
                        else
                        {
                            check = writeLog(sqlCommand, transaction, sqlConnection, dto.idProduct, STATUS_INACTIVE, idEmployee);
                        }
                        
                    }
                    transaction.Commit();
                    return check;
                }
            }
            catch (SqlException e)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw new Exception(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(null, sqlConnection);
            }
            return false;
        }

        public TblProductsDTO getProduct(string idProduct)
        {
            string sql = "select p.idProduct,p.name,p.price,p.quantity,p.status,p.idCategory,c.name as categoryName " +
                "from tblProducts p,tblCategory c " +
                "where p.idCategory = c.idCategory AND p.status = 1 AND p.quantity > 0 AND idProduct = @idProduct";
            try
            {
                sqlConnection = DBUtil.MakeConnect();
                if (sqlConnection != null)
                {
                    sqlCommand = new SqlCommand(sql, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@idProduct", idProduct);
                    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (sqlDataReader.Read())
                    {
                        TblProductsDTO product = new TblProductsDTO();
                        product.idProduct = sqlDataReader["idProduct"].ToString();
                        product.name = sqlDataReader["name"].ToString();
                        product.price = float.Parse(sqlDataReader["price"].ToString());
                        product.quantity = int.Parse(sqlDataReader["quantity"].ToString());
                        product.status = bool.Parse(sqlDataReader["status"].ToString());
                        product.idCategory = sqlDataReader["idCategory"].ToString();
                        product.categoryName = sqlDataReader["categoryName"].ToString();
                        return product;
                    }
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
    }
}
