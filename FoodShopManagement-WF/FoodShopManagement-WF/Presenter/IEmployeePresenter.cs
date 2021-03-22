using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace FoodShopManagement_WF.Presenter
{
    interface IEmployeePresenter
    {
        void InsertEmployee();
        void loadEmp();
        void LoadEmpByRole(frmManager_v2 form);
        void DeleteEmployee(frmManager_v2 form);
        void searchEmployee();
<<<<<<< HEAD:FoodShopManagement-WF/FoodShopManagement-WF/Presenter/IEmployeePresenter.cs
        void UpdateEmployee();
        bool UpdateEmpDetail(frmMyProfileDetailcs form);
=======
>>>>>>> ab954045bfaee2e036f5bc8c03efead4cdf0cc1b:FoodShopManagement-WF/FoodShopManagement-WF/Presenter/IManagerDetailPresenter.cs
    }
}
