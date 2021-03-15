using DTO;
using FoodShopManagementApi.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FoodShopManagementApi.DAO
{
    public class TblCategoryDAO
    {
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataReader reader = null;

        public List<TblCategoryDTO> loadCategory()
        {
            string sql = "SELECT idCategory, name FROM tblCategory";
            try
            {
                cn = DBUtil.MakeConnect();
                if (cn != null)
                {
                    cmd = new SqlCommand(sql, cn);
                    reader = cmd.ExecuteReader();
                    List<TblCategoryDTO> listCategory = null;
                    while (reader.Read())
                    {
                        TblCategoryDTO dto = new TblCategoryDTO();
                        dto.idCategory = reader["idCategory"].ToString();
                        dto.name = reader["name"].ToString();

                        if (listCategory == null)
                        {
                            listCategory = new List<TblCategoryDTO>();
                        }

                        listCategory.Add(dto);
                    }
                    return listCategory;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            } finally
            {
                DBUtil.CloseConnection(reader, cn);
            }
            return null;
        }
    }
}
