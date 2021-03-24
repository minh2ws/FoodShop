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
        void updateEmp();
        void saveEmployee(frmEmployeeDetail detail);
        bool UpdateEmpDetail(frmMyProfileDetailcs form);
        void LoadCustomers();
        void SearchCustomer();
        void LoadRevenues(DateTime date);
    }
}
