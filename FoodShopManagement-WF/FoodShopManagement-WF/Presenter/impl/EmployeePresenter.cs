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
        private BindingSource bsCustomer;
        private BindingSource bsOrderdetail;
        private IEmployeeModel model = new EmployeeModel();
        private ICustomerModel customerModel = new CustomerModel();
        private IOrderModel orderModel = new OrderModel();
        public EmployeePresenter(frmManager_v2 form)
        {
            this.form = form;
        }
        public EmployeePresenter()
        {

        }
        bool ValidateEmplpyee(TblEmployeesDTO e)
        {
            if (e.idEmployee.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("username can't empty!!", "Error");
                return false;
            }
            if (e.name.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Name can't empty!!", "Error");
                return false;
            }

            if (e.password.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Password can't empty!!", "Error");
                return false;
            }
            if (e.role.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Role can't empty!!", "Error");
                return false;
            }
            return true;
            //if (e.status.Trim().Length == 0)
            //{
            //    System.Windows.Forms.MessageBox.Show("status can't empty!!", "Error");
            //    return false;
            //}
            //return true;
        }
        public void InsertEmployee()
        {
            frmEmployeeDetail detail = new frmEmployeeDetail(true, this);
            detail.setIsUpdate(false);
            DialogResult r = detail.ShowDialog();

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
        public bool UpdateEmpDetail(frmMyProfileDetailcs detail)
        {
            TblEmployeesDTO emp = new TblEmployeesDTO
            {
                idEmployee= detail.getId(),
                name = detail.getTxtName(),
                password = detail.getTxtPassword(),
            };
            bool isSuccess = checkField(emp);
            if (isSuccess)
            {
              
                return model.UpdateEmpDetail(emp);//return true if update sucess
            }
            return false;
        }
        public void saveEmployee(frmEmployeeDetail detail)
        {
            TblEmployeesDTO emp = new TblEmployeesDTO();
            emp.idEmployee = detail.getUserName();
            emp.name = detail.getFullName();
            emp.password = detail.getPassword();
            emp.role = detail.getRole().Trim();
            bool status = true ;
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
            if (validate)
            {
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
            detail.selectrole(form.getRoletext());
            detail.selectstatus(form.getStatus().Text);
           // detail.selectstatus(bool.Parse(form.getStatus().Text));
            DialogResult r = detail.ShowDialog();
          
        }
        public void LoadCustomers()
        {
            List<TblCustomerDTO> listCustomers = customerModel.getCustomers();
            DataTable dtCustomer = ConvertCustom.ListToDataTable<TblCustomerDTO>(listCustomers);
            bsCustomer = new BindingSource()
            {
                DataSource = dtCustomer
            };

            //binding data to data grid view
            form.getBnCustomer().BindingSource = bsCustomer;
            form.getDgvCustomer().DataSource = bsCustomer;

            //hide unnecessary column
            form.getDgvCustomer().Columns["phone"].Visible = false;
            form.getDgvCustomer().Columns["address"].Visible = false;
            form.getDgvCustomer().Columns["point"].Visible = false;

            //clear and add new data binding
            clearDataBindingTextCustomer();
            bindingDataTextCustomer();
        }

        public void clearDataBindingTextCustomer()
        {
            form.getCustomerId().DataBindings.Clear();
            form.getCustomerName().DataBindings.Clear();
            form.getCustomerPhone().DataBindings.Clear();
            form.getCustomerAddress().DataBindings.Clear();
            form.getCustomerPoint().DataBindings.Clear();
        }

        public void bindingDataTextCustomer()
        {
            form.getCustomerId().DataBindings.Add("Text", bsCustomer, "idCustomer");
            form.getCustomerName().DataBindings.Add("Text", bsCustomer, "name");
            form.getCustomerPhone().DataBindings.Add("Text", bsCustomer, "phone");
            form.getCustomerAddress().DataBindings.Add("Text", bsCustomer, "address");
            form.getCustomerPoint().DataBindings.Add("Text", bsCustomer, "point");
        }

        public void SearchCustomer()
        {
            string searchValue = form.getSearchCustomer().Text;
            if (searchValue.Equals(""))
            {
                bsCustomer.Filter = "";
            }
            else
            {
                bsCustomer.Filter = "name like '%" + searchValue + "%'";
            }
        }

        public void LoadRevenues(DateTime date)
        {
            float total = orderModel.LoadTotal(date);
            List<RevenuesDTO> listDetail = orderModel.LoadOrderDetail(date);
            if (listDetail.Count >0)
            {
                DataTable dtOrderDetail = ConvertCustom.ListToDataTable<RevenuesDTO>(listDetail);
                bsOrderdetail = new BindingSource()
                {
                    DataSource = dtOrderDetail
                };
            
            //binding data to data grid view
            form.getBnOrderDetail().BindingSource = bsOrderdetail;
            form.getDgvOrderDetail().DataSource = bsOrderdetail;
            form.gettotal().Text = total.ToString() ;
            //hide unnecessary column
            form.getDgvOrderDetail().Columns["Customer"].Visible = false;
            form.getDgvOrderDetail().Columns["Salesman"].Visible = false;
            form.getDgvOrderDetail().Columns["total"].Visible = false;

            //clear and add new data binding
            clearDataBindingTextOrderdetail();
            bindingDataTextOrderdetail();
            }
        }

        public void clearDataBindingTextOrderdetail()
        {
            form.getcustomer().DataBindings.Clear();
            form.getsalesman().DataBindings.Clear();
            form.getproductname().DataBindings.Clear();
            form.getquantity().DataBindings.Clear();
            form.getprice().DataBindings.Clear();
          
        }

        public void bindingDataTextOrderdetail()
        {
            form.getcustomer().DataBindings.Add("Text", bsOrderdetail, "Customer");
            form.getsalesman().DataBindings.Add("Text", bsOrderdetail, "Salesman");
            form.getproductname().DataBindings.Add("Text", bsOrderdetail, "Productname");
            form.getprice().DataBindings.Add("Text", bsOrderdetail, "Price");
            form.getquantity().DataBindings.Add("Text", bsOrderdetail, "Quantity");
     
        }

        public void SearchRevenues(DateTime date)
        {
            float total = orderModel.LoadTotal(date);
            List<RevenuesDTO> listDetail = orderModel.LoadOrderDetail(date);
            if (listDetail != null)
            {
                DataTable dtOrderDetail = ConvertCustom.ListToDataTable<RevenuesDTO>(listDetail);
                bsOrderdetail = new BindingSource()
                {
                    DataSource = dtOrderDetail
                };

                //binding data to data grid view
                form.getBnOrderDetail().BindingSource = bsOrderdetail;
                form.getDgvOrderDetail().DataSource = bsOrderdetail;
                form.gettotal().Text = total.ToString();
                //hide unnecessary column
                form.getDgvOrderDetail().Columns["Customer"].Visible = false;
                form.getDgvOrderDetail().Columns["Salesman"].Visible = false;
                form.getDgvOrderDetail().Columns["total"].Visible = false;

                //clear and add new data binding
                clearDataBindingTextOrderdetail();
                bindingDataTextOrderdetail();
            }
        }
    }
}
