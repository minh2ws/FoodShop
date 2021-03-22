﻿using DTO;
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
        bool ValidateEmplpyee(TblEmployeesDTO e)
        {
            if (e.idEmployee == null || e.name == null || e.password == null)
                return false;
            return true;
        }
        public void InsertEmployee()
        {
            frmEmployeeDetail detail = new frmEmployeeDetail(true, this);
            detail.setIsUpdate(false);
            DialogResult r = detail.ShowDialog();

        }
        public void saveEmployee(frmEmployeeDetail detail)
        {
            TblEmployeesDTO emp = new TblEmployeesDTO();
            emp.idEmployee = detail.getUserName();
            emp.name = detail.getFullName();
            emp.password = detail.getPassword();
            emp.role = detail.getRole().Trim();
            bool status = false;
            if (detail.getStatus().Trim().Equals("True"))
            {
                status = true;
            }
            else
            {
                status = false;
            }
            emp.status = status;

            bool validate = ValidateEmplpyee(emp);
            if (!detail.getIsUpdate())
            {
                if (model.InsertEmployee(emp))
                {
                    MessageBox.Show(MessageUtil
                        .SAVE_SUCCESS);
                }
                else
                {
                    MessageBox.Show(MessageUtil.ERROR + " add Employee");
                }
            }
            else
            {
                if (model.UpdateEmployee(emp))
                {
                    MessageBox.Show(MessageUtil
                        .SAVE_SUCCESS);
                }
                else
                {
                    MessageBox.Show(MessageUtil.ERROR + " update Employee");
                }
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

        public void DeleteEmployee(frmManager_v2 form)
        {

            try
            {
                string id = form.getID();
                Boolean emp = model.DeleteEmployee(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Delete Employee");
            }
        }

        public void updateEmp()
        {
            frmEmployeeDetail detail = new frmEmployeeDetail(true, this);
            detail.setIsUpdate(true);

            //lấy dữ liệu gán vào textbox
            detail.getID().Text = form.getIdEmp().Text;
            detail.getName().Text = form.getEmpName().Text;
            detail.getPwd().Text = form.getPassword().Text;
            
            DialogResult r = detail.ShowDialog();
          
        }
    }
}