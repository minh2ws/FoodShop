using DTO;
using DTO.Model;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter.impl
{
    class ManagerDetailPresenter: IManagerDetailPresenter
    {
         IManagerDetailModel ManagerDetail = new ManagerDetailModel();
        public bool InsertEmployee(frmEmployeeDetail form)
        {
            TblEmployeesDTO Employees = new TblEmployeesDTO();
            Employees.idEmployee = form.getUserName().Trim();
            Employees.name = form.getFullName().Trim();
            Employees.password = form.getPassword().Trim();
            Employees.role = form.getRole().Trim();
            Employees.status = true;
            TblEmployeesDTO emp = ManagerDetail.InsertEmployee(Employees);
            if (emp != null)
            {
                return true;
            }
            return false;
        }

        public List<TblEmployeesDTO> loadData(frmManager_v2 form)
        {
            LoadEmployeeModel model = new LoadEmployeeModel
            {
                role = form.getRole()
            };

            List<TblEmployeesDTO> result = ManagerDetail.loadData(model);
                return result;
        }

      
    }
}
