using DTO;
using DTO.Model;
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

        TblEmployeesDTO DeleteEmployee(TblEmployeesDTO id);

        //List<LoadEmployeeModel> loadData(TblEmployeesDTO model);
        List<TblEmployeesDTO> loadEmployeeDTO(TblEmployeesDTO model);
    }
}
