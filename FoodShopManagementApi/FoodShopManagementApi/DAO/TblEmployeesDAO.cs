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
    public class TblEmployeesDAO
    {
        public TblEmployeesDTO checkLogin(string idEmployee, string password)
        {
            SqlConnection connection = DBUtil.MakeConnect();
            SqlDataReader sqlDataReader = null;

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
                    int idEmployeeCompare = sqlDataReader.GetInt32("idEmployee");
                    string passwordCompare = sqlDataReader.GetString("password");
                    if (idEmployeeCompare.Equals(idEmployee) && passwordCompare.Equals(password))
                    {
                        TblEmployeesDTO employee = new TblEmployeesDTO();
                        employee.IdEmployee = idEmployee;
                        employee.Password = password;
                        employee.Name = sqlDataReader.GetString("name");
                        employee.Role = sqlDataReader.GetString("name");
                        employee.status = sqlDataReader.GetString("name");
                        employee.IdEmployee = idEmployee;
                    }
                }
            }
        }
    }
}
