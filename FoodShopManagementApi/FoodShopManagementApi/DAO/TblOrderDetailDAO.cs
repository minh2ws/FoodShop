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

        public static TblOrderDetailDAO getInstance()
        {
            if (instance == null)
            {
                instance = new TblOrderDetailDAO();
            }
            return instance;
        }

        private SqlConnection cn = null;
        private SqlCommand cmd = null;

        public bool AddOrderDetail(CartDTO cart)
        {
            string sql = "INSERT tblOrderDetail(idOrder, idProduct, quantity, price) " +
                "VALUES (@idOrder, @idProduct, @quantity, @price) ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    int row = 0;
                    foreach (var item in cart.itemsList)
                    {
                        cmd = new SqlCommand(sql, cn);
                        cmd.Parameters.AddWithValue("@idOrder", item.idOrder);
                        cmd.Parameters.AddWithValue("@idProduct", item.idProduct);
                        cmd.Parameters.AddWithValue("@quantity", item.quantity);
                        cmd.Parameters.AddWithValue("@price", item.price);
                        cmd.ExecuteNonQuery();
                        row++;
                    }

                    if (row == cart.itemsList.Count)
                    {
                        return true;
                    }
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
