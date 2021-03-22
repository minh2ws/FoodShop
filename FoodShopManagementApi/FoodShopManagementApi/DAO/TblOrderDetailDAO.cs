using DTO;
using FoodShopManagementApi.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.DAO
{
    public class TblOrderDetailDAO
    {
        //SINGLETON pattern
        private static TblOrderDetailDAO instance;

        private TblOrderDetailDAO() { }

        public TblOrderDetailDAO getInstance()
        {
            if (instance == null)
            {
                instance = new TblOrderDetailDAO();
            }
            return instance;
        }

        private SqlConnection cn = null;
        private SqlCommand cmd = null;

        public bool AddOrderDetail(string orderId, List<TblOrderDetailDTO> itemsList)
        {
            string sql = "INSERT tblOrderDetail(idOrder, idProduct, quantity, price) " +
                "VALUES (@idOrder, @idProduct, @quantity, @price) ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    SqlTransaction transaction = cn.BeginTransaction();
                    foreach (var orderDetail in itemsList)
                    {
                        cmd = new SqlCommand(sql, cn, transaction);
                        cmd.Parameters.AddWithValue("@idOrder", orderDetail.idOrder);
                        cmd.Parameters.AddWithValue("@idProduct", orderDetail.idProduct);
                        cmd.Parameters.AddWithValue("@quantity", orderDetail.quantity);
                        cmd.Parameters.AddWithValue("@price", orderDetail.price);
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
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
