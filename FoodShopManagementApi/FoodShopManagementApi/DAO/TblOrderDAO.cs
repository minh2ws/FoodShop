using DTO;
using FoodShopManagementApi.Util;
using System;
using System.Collections.Generic;
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

        public TblOrderDAO getInstance()
        {
            if (instance == null)
            {
                instance = new TblOrderDAO();
            }
            return instance;
        }

        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

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
                    cmd.Parameters.AddWithValue("@priceTotal", dto.priceSum);
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
    }
}
