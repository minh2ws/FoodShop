using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using FoodShopManagement_WF.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter.impl
{
    class ManagerDetailPresenter : IManagerDetailPresenter
    {
        private frmManager_v2 form;
        private BindingSource bsEmp;
        private IManagerDetailModel model = new ManagerDetailModel();
        public ManagerDetailPresenter(frmManager_v2 form)
        {
            this.form = form;
        }
        public ManagerDetailPresenter()
        {

        }
        bool ValidateEmplpyee(TblEmployeesDTO e)
        {
            if (e.idEmployee == null || e.name == null || e.password == null)
                return false;
            return true;
        }
        public bool InsertEmployee(frmEmployeeDetail form)
        {
            TblEmployeesDTO Employees = new TblEmployeesDTO();
            Employees.idEmployee = form.getUserName().Trim();
            Employees.name = form.getFullName().Trim();
            Employees.password = form.getPassword().Trim();
            Employees.role = form.getRole().Trim();
            Employees.status = true;
            bool validate = ValidateEmplpyee(Employees);
            if (validate == true)
            {
                TblEmployeesDTO emp = model.InsertEmployee(Employees);
                if (emp != null)
                {
                    return true;
                }
                return false;

            }
            else
            {
                return false;
            }
        }

        private void clearDataBindingTextEmployee()
        {
            form.getIdEmp().DataBindings.Clear();
            form.getEmpName().DataBindings.Clear();
            form.getPassword().DataBindings.Clear();

        }
        public void loadEmp()
        {
            try
            {
                List<TblEmployeesDTO> listEmp = model.getAll();
                DataTable dataTable = ConvertCustom.ListToDataTable(listEmp);
                bsEmp = new BindingSource()
                {
                    DataSource = dataTable
                };
                form.GetDataGridViewEmployee().DataSource = bsEmp;
                form.GetBindingNavigator().BindingSource = bsEmp;
                clearDataBindingTextEmployee();
            }
            catch (Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Get All Employee");
            }
        }

        public void LoadEmpByRole(frmManager_v2 form)
        {
            try
            {
                string role = form.getRole();
                List<TblEmployeesDTO> list = model.LoadEmpByRole(role);
                DataTable dataTable = ConvertCustom.ListToDataTable(list);
                bsEmp = new BindingSource()
                {
                    DataSource = dataTable
                };
                form.GetDataGridViewEmployee().DataSource = bsEmp;
            }
            catch (Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Load Employee By Role");
            }
        }


        /* public List<TblEmployeesDTO> loadEmployeeDTO(frmManager_v2 form)
         {
             TblEmployeesDTO model = new TblEmployeesDTO
             {
                 role = form.getRole()
             };

             List<TblEmployeesDTO> result = ManagerDetail.loadEmployeeDTO(model);
             return result;
         }*/

        public bool DeleteEmployee(string id)
        {
            throw new NotImplementedException();
        }
    }
}
