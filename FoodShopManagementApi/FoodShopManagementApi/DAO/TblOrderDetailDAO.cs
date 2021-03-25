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

        public List<RevenuesDTO> SelectOrderDetail(DateTime date)
        {
            SqlConnection connection = null;
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            string sql = "select tblProducts.name as product,tblProducts.price,tblOrderDetail.quantity,tblOrder.idEmployee,tblCustomers.name as customer" +
                " from tblOrderDetail  " +
                "left join tblOrder " +
                " on tblOrderDetail.idOrder = tblOrder.idOrder " +
                "left join tblCustomers " +
                " on tblCustomers.idCustomer = tblOrder.idCustomer " +
                " left join tblProducts " +
                " on tblOrderDetail.idProduct = tblProducts.idProduct " +
                " where CAST(tblOrder.orderDate as DATE) = @date ";
            try
            {
                connection = DBUtil.MakeConnect();
                if (connection != null)
                {
                    string date_str = date.ToString("yyyy-MM-dd");
                    sqlCommand = new SqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@date", date_str);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    List<RevenuesDTO> result = new List<RevenuesDTO>();
                    while (sqlDataReader.Read())
                    {
                        RevenuesDTO detail = new RevenuesDTO();
                        detail.Productname = sqlDataReader["product"].ToString();
                        detail.Price = float.Parse(sqlDataReader["price"].ToString());
                        detail.Quantity = int.Parse(sqlDataReader["quantity"].ToString());
                        detail.Salesman = sqlDataReader["idEmployee"].ToString();
                        detail.Customer = sqlDataReader["customer"].ToString();
                        result.Add(detail);
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
                DBUtil.CloseConnection(sqlDataReader, connection);
            }
            return null;
        }

    }
}
