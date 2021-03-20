using DTO;
using FoodShopManagementApi.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.DAO
{
    public class TblCustomerDAO
    {
        //Using SINGLETON pattern
        private static TblCustomerDAO instance;

        private TblCustomerDAO() { }

        public static TblCustomerDAO getInstance()
        {
            if (instance == null)
            {
                instance = new TblCustomerDAO();
            }
            return instance;
        }

        private SqlConnection cn = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader = null;

        public List<TblCustomerDTO> loadCustomers()
        {
            string sql = "SELECT idCustomer, name, phone, address, point " +
                "FROM tblCustomers ";
            List<TblCustomerDTO> listCustomer = null;
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TblCustomerDTO customer = new TblCustomerDTO()
                        {
                            idCustomer = reader["idCustomer"].ToString(),
                            name = reader["name"].ToString(),
                            phone = reader["phone"].ToString(),
                            address = reader["address"].ToString(),
                            point = int.Parse(reader["point"].ToString())
                        };

                        if (listCustomer == null)
                        {
                            listCustomer = new List<TblCustomerDTO>();
                        }

                        listCustomer.Add(customer);
                    }
                    return listCustomer;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(reader, cn);
            }
            return listCustomer;
        }
    }
}
