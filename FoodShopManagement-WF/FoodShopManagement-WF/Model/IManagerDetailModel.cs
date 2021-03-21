using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Model
{
    interface IManagerDetailModel
    {
        TblEmployeesDTO InsertEmployee(TblEmployeesDTO TblEmployeesDTO);

        Boolean DeleteEmployee(string idEmployee);

        List<TblEmployeesDTO> LoadEmpByRole(string role);

        List<TblEmployeesDTO> getAll();

    }
}
