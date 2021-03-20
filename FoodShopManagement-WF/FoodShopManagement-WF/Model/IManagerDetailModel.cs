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

        bool DeleteEmployee(TblEmployeesDTO empID);

        List<TblEmployeesDTO> loadEmployeeDTO(TblEmployeesDTO model);
    }
}
