using DTO;
using FoodShopManagementApi.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.DAO
{
    public class TblOrderDAO
    {
        //SINGLETON pattern
        private static TblOrderDAO instance;

        private TblOrderDAO() { }

        public static TblOrderDAO getInstance()
        {
            if (instance == null)
            {
                instance = new TblOrderDAO();
            }
            return instance;
        }

        SqlConnection cn = null;
        SqlCommand cmd = null;

        public bool AddOrder(TblOrderDTO dto)
        {
            string sql = "INSERT tblOrder(idOrder, idCustomer, idEmployee, priceSum, discount, priceTotal, orderDate) " +
                "VALUES(@idOrder, @idCustomer, @idEmp, @price, @discount, @priceTotal, @orderDate) ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@idOrder", dto.idOrder);
                    cmd.Parameters.AddWithValue("@idCustomer", dto.idCustomer);
                    cmd.Parameters.AddWithValue("@idEmp", dto.idEmployee);
                    cmd.Parameters.AddWithValue("@price", dto.priceSum);
                    cmd.Parameters.AddWithValue("@discount", dto.discount);
                    cmd.Parameters.AddWithValue("@priceTotal", dto.total);
                    cmd.Parameters.AddWithValue("@orderDate", dto.orderDate);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(null, cn);
            }
            return false;
        }

        public float SelectTotalOrder(DateTime date)
        {
            SqlConnection connection = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                connection = DBUtil.MakeConnect();
                if (connection != null)
                {
                    string date_str = date.ToString("yyyy-MM-dd");
                    String sql = "select sum(priceTotal) as total from tblOrder where orderDate BETWEEN '" + date_str + "' AND '" + date_str + " 23:59:59' ";
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                   
                    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (sqlDataReader.Read())
                    {
                        float total =float.Parse(sqlDataReader.GetString("total"));
                        return total;
                    }
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally
            {
                DBUtil.CloseConnection(sqlDataReader, connection);
            }
            return 0;
        }
    }
}
