using DTO;
using FoodShopManagementApi.Util;
using System;
using System.Data;
using System.Data.SqlClient;

namespace FoodShopManagementApi.DAO
{
    public class TblEmployeesDAO
    {
        public TblEmployeesDTO CheckLogin(string idEmployee, string password)
        {
            SqlConnection connection = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                connection = DBUtil.MakeConnect();
                if (connection != null)
                {
                    String sql = "Select idEmployee, password, name, role, status " +
                        "From tblEmployees " +
                        "Where idEmployee = @idEmployee and password = @password";
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idEmployee", idEmployee);
                    sqlCommand.Parameters.AddWithValue("@password", password);
                    sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    if (sqlDataReader.Read())
                    {
                        string idEmployeeCompare = sqlDataReader.GetString("idEmployee");
                        string passwordCompare = sqlDataReader.GetString("password");
                        if (idEmployeeCompare.Equals(idEmployee) && passwordCompare.Equals(password))
                        {
                            TblEmployeesDTO employee = new TblEmployeesDTO();
                            employee.idEmployee = sqlDataReader.GetString("idEmployee");
                            employee.password = sqlDataReader.GetString("password");
                            employee.name = sqlDataReader.GetString("name");
                            employee.role = sqlDataReader.GetString("role");
                            employee.status = sqlDataReader.GetBoolean("status");
                            return employee;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (sqlDataReader != null) sqlDataReader.Close();
            }
            return null;
        }
    }
}
