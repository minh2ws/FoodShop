using DTO;
using FoodShopManagementApi.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FoodShopManagementApi.DAO
{
    public class TblEmployeesDAO
    {
        //Using SINGLETON pattern
        private static TblEmployeesDAO instance = null;
        
        private TblEmployeesDAO() { }

        public static TblEmployeesDAO getInstance()
        {
            if (instance == null)
            {
                instance = new TblEmployeesDAO();
            }
            return instance;
        }

        public List<TblEmployeesDTO> loadEmp() {
            string sql = "select idEmployee, name, password, role, status " +
                "from tblEmployees " +
                "where role not like 'Manager'";
            SqlConnection connection = null;
            SqlDataReader reader = null;
            SqlCommand cmd = null;

            try
            {
                connection = DBUtil.MakeConnect();
                if (connection != null)
                {
                    cmd = new SqlCommand(sql, connection);
                    reader = cmd.ExecuteReader();
                    List<TblEmployeesDTO> list = new List<TblEmployeesDTO>();
                    while (reader.Read())
                    {
                        TblEmployeesDTO dto = new TblEmployeesDTO();
                        dto.idEmployee = reader["idEmployee"].ToString();
                        dto.name = reader["name"].ToString();
                        dto.password = reader["password"].ToString();
                        dto.role = reader["role"].ToString();
                        dto.status = bool.Parse(reader["status"].ToString());

                        list.Add(dto);
                    }
                    return list;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                DBUtil.CloseConnection(reader, connection);
            }
            return null;
        }
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
                        "Where idEmployee = @idEmployee and password = @password ";
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
                            TblEmployeesDTO emp = new TblEmployeesDTO()
                            {
                                idEmployee = sqlDataReader["idEmployee"].ToString(),
                                password = sqlDataReader["password"].ToString(),
                                name = sqlDataReader["name"].ToString(),
                                role = sqlDataReader["role"].ToString(),
                                status = bool.Parse(sqlDataReader["status"].ToString())
                            };
                            return emp;
                        }
                    }
                }
            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally
            {
                DBUtil.CloseConnection(sqlDataReader, connection);

            }
            return null;
        }


        public bool AddEmployee(TblEmployeesDTO emp)
        {
            SqlConnection connection = null;
            SqlDataReader sqlDataReader = null;
            bool result = false;
            try
            {
                connection = DBUtil.MakeConnect();
                if (connection != null)
                {
                    String sql = "INSERT tblEmployees(idEmployee, password, name, role, status) " +
                        "values(@idEmployee ,@password,@name,@role ,@status)";
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@idEmployee", emp.idEmployee);
                    sqlCommand.Parameters.AddWithValue("@password", emp.password);
                    sqlCommand.Parameters.AddWithValue("@name", emp.name);
                    sqlCommand.Parameters.AddWithValue("@role", emp.role);
                    sqlCommand.Parameters.AddWithValue("@status", emp.status);

                    //sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    result = sqlCommand.ExecuteNonQuery() > 0;
                }

            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally
            {
                DBUtil.CloseConnection(sqlDataReader, connection);
            }
            return result;
        }
        public bool UpdateEmployee(TblEmployeesDTO emp)
        {
            SqlConnection connection = null;
            SqlDataReader sqlDataReader = null;
            bool result = false;
            try
            {
                connection = DBUtil.MakeConnect();
                if (connection != null)
                {
                    String sql = "UPDATE tblEmployees " +
                        "SET name=@name, password=@password, role=@role, status=@status " +
                        "WHERE idEmployee=@idEmployee";
                    SqlCommand sqlCommand = new SqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@password", emp.password);
                    sqlCommand.Parameters.AddWithValue("@name", emp.name);
                    sqlCommand.Parameters.AddWithValue("@role", emp.role);
                    sqlCommand.Parameters.AddWithValue("@status", emp.status);
                    sqlCommand.Parameters.AddWithValue("@idEmployee", emp.idEmployee);
                    //sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    result = sqlCommand.ExecuteNonQuery() > 0;
                }

            }
            catch (SqlException e) { throw new Exception(e.Message); }
            finally
            {
                DBUtil.CloseConnection(sqlDataReader, connection);
            }
            return result;
        }
        public List<TblEmployeesDTO> loadEmpByRole(string role)
        {
            SqlConnection connection = null;
            SqlDataReader sqlDataReader = null;
            SqlCommand sqlCommand = null;
            string sql = "select idEmployee, name , password, role, status  " +
                 "from tblEmployees " +
                 "where role = @role ";
            try
            {
                connection = DBUtil.MakeConnect();
                if (connection != null)
                {
                    sqlCommand = new SqlCommand(sql, connection);
                    sqlCommand.Parameters.AddWithValue("@role", role);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    List<TblEmployeesDTO> result = new List<TblEmployeesDTO>();
                    while (sqlDataReader.Read())
                    {
                        TblEmployeesDTO emp = new TblEmployeesDTO();
                        emp.idEmployee = sqlDataReader["idEmployee"].ToString();
                        emp.name = sqlDataReader["name"].ToString();
                        emp.password = sqlDataReader["password"].ToString();
                        emp.role = sqlDataReader["role"].ToString();
                        emp.status = bool.Parse(sqlDataReader["status"].ToString());
                        result.Add(emp);
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

        public bool UpdateEmployeeDetail(TblEmployeesDTO emp)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;
            
            string sql = "UPDATE tblEmployees " 
                    + "SET name = @name, password = @pwd "
                    + "WHERE idEmployee = @id ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@name", emp.name);
                    cmd.Parameters.AddWithValue("@pwd", emp.password);
                    cmd.Parameters.AddWithValue("@id", emp.idEmployee);

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

        public bool DeleteEmployee(string id)
        {
            SqlConnection cn = null;
            SqlCommand cmd = null;

            string sql = "UPDATE tblEmployees "
                    + "SET status = 0 "
                    + "WHERE idEmployee = @id ";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("@id", id);
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
