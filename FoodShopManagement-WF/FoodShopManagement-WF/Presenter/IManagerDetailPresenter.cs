using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FoodShopManagement_WF.Presenter
{
    interface IManagerDetailPresenter
    {
        bool InsertEmployee(frmEmployeeDetail form);
        void loadEmp();
        void LoadEmpByRole(frmManager_v2 form);
        void DeleteEmployee(frmManager_v2 form);
    }
}
