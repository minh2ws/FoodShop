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
    public class EmployeePresenter : IEmployeePresenter

    {
        private frmManager_v2 form;
        private BindingSource bsEmp;
        private IEmployeeModel model = new EmployeeModel();
        public EmployeePresenter(frmManager_v2 form)
        {
            this.form = form;
        }
        public EmployeePresenter()
        {

        }

        public bool checkField(TblEmployeesDTO emp)
        {
            if (emp.name.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Name can't empty!!", "Error");
                return false;
            }

            if (emp.password.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Password can't empty!!", "Error");
                return false;
            }
            return true;
        }
        public bool UpdateEmpDetail(frmMyProfileDetailcs form)
        {
            TblEmployeesDTO emp = new TblEmployeesDTO
            {
                name = form.getTxtName(),
                password = form.getTxtPassword(),
            };
            bool isSuccess = checkField(emp);
            if (isSuccess)
            {
                return model.UpdateProfile(emp);//return true if update sucess
            }
            return false;
        }
        bool ValidateEmplpyee(TblEmployeesDTO e)
        {
            if (e.idEmployee == null || e.name == null || e.password == null)
                return false;
            return true;
        }

        public void InsertEmployee()
        {
            frmEmployeeDetail empDetail = new frmEmployeeDetail(true,this);
            DialogResult r = empDetail.ShowDialog();
            empDetail.setFlag(false);
            TblEmployeesDTO emp = new TblEmployeesDTO();
            emp.idEmployee = empDetail.getUserName().Text;
            emp.name = empDetail.getFullName().Text;
            emp.password = empDetail.getPassword().Text;
            emp.role = empDetail.getEmpRole();
            emp.status = true;
     
            
            bool dto = model.InsertEmployee(emp);
            if (dto==true)
            {
                MessageBox.Show("Insert complete!");
            }
            else
            {
                MessageBox.Show("Insert fail!");
            }
           
        }
        public void searchEmployee()
        {
            try
            {
                string search = form.getSearchEmpBox().Text;
                bsEmp.Filter = "name like '%" + search + "%'";
            }
            catch (Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Search Employee");
            }

        }
        private void clearDataBindingTextEmployee()
        {
            form.getIdEmp().DataBindings.Clear();
            form.getEmpName().DataBindings.Clear();
            form.getPassword().DataBindings.Clear();
            form.getEmpRole().DataBindings.Clear();
            form.getStatus().DataBindings.Clear();
        }
        public void bindingSource()
        {
            form.GetDataGridViewEmployee().DataSource = bsEmp;
            form.GetBindingNavigator().BindingSource = bsEmp;
            clearDataBindingTextEmployee();
            form.getIdEmp().DataBindings.Add("Text", bsEmp, "idEmployee");
            form.getEmpName().DataBindings.Add("Text", bsEmp, "name");
            form.getPassword().DataBindings.Add("Text", bsEmp, "password");
            form.GetDataGridViewEmployee().Columns["password"].Visible = false;
            form.getEmpRole().DataBindings.Add("Text", bsEmp, "role");
            form.GetDataGridViewEmployee().Columns["role"].Visible = false;
            form.getStatus().DataBindings.Add("Text", bsEmp, "status");
            form.GetDataGridViewEmployee().Columns["status"].Visible = false;
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
                bindingSource();

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
                bindingSource();
            }
            catch (Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Load Employee By Role");
            }
        }

        public void searchEmployee()
        {
            try
            {
                string search = form.getSearchEmpBox().Text;
                bsEmp.Filter = "name like '%" + search + "%'";
            }
            catch (Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Search Employee");
            }

        }
        public void DeleteEmployee(frmManager_v2 form)
        {

            try
            {
                string id = form.getID();
                Boolean emp = model.DeleteEmployee(id);
            }catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Delete Employee");
            }
        }

        public void UpdateEmployee()
        {
            //get Emp from form
            frmEmployeeDetail empDetail = new frmEmployeeDetail(true,this);
            
            
            empDetail.getUserName().Text = form.getIdEmp().Text;
            empDetail.getFullName().Text = form.getEmpName().Text;
            empDetail.getPassword().Text = form.getPassword().Text;
           // empDetail.setRole = form.getEmpRole().Text;
            DialogResult r = empDetail.ShowDialog();



        }
    }
}
