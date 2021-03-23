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

        public bool AddCustomer(TblCustomerDTO dto)
        {
            string sql = "INSERT tblCustomers(name, phone, address, point) " +
                "VALUES(@name, @phone, @address, @point) ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@name", dto.name);
                    cmd.Parameters.AddWithValue("@phone", dto.phone);
                    cmd.Parameters.AddWithValue("@address", dto.address);
                    cmd.Parameters.AddWithValue("@point", dto.point);

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

        public bool UpdateCustomer(TblCustomerDTO dto)
        {
            string sql = "UPDATE tblCustomers " +
                "SET name=@name, phone=@phone, address=@address " +
                "WHERE idCustomer=@id ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@id", dto.idCustomer);
                    cmd.Parameters.AddWithValue("@name", dto.name);
                    cmd.Parameters.AddWithValue("@phone", dto.phone);
                    cmd.Parameters.AddWithValue("@address", dto.address);

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

        public bool UpdatePoint(TblCustomerDTO dto)
        {
            string sql = "UPDATE tblCustomers " +
                "SET point = @point " +
                "WHERE idCustomer = @id ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@point", dto.point);
                    cmd.Parameters.AddWithValue("@id", dto.idCustomer);

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
