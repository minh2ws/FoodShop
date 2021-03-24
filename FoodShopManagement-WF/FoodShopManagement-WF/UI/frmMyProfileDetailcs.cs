using DTO;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using FoodShopManagement_WF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.UI
{
    public partial class frmMyProfileDetailcs : Form
    {
        private IEmployeePresenter presenter = new EmployeePresenter();
        private TblEmployeesDTO emp;

        public TblEmployeesDTO getEmployee()
        {
            return this.emp;
        }
        public string getId()
        {
            return txtEmployeeID.Text;
        }
        public string getTxtName()
        {
            return txtFullName.Text;
        }

        public string getTxtPassword()
        {
            return txtPassword.Text;
        }

        public frmMyProfileDetailcs()
        {
            InitializeComponent();
        }

        public frmMyProfileDetailcs(TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.emp = emp;
            loadEmpDetail();
        }

        private void loadEmpDetail()
        {
            //turn off all field
            txtEmployeeID.ReadOnly = true;
            txtFullName.ReadOnly = true;
            txtPassword.ReadOnly = true;

            txtEmployeeID.Text = emp.idEmployee;
            txtFullName.Text = emp.name;
            txtPassword.Text = emp.password;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text.Equals("Edit"))
            {
                //turn on field for Edit
                txtFullName.ReadOnly = false;
                txtPassword.ReadOnly = false;

                btnEdit.Text = "Cancel";
            } 
            else
            {
                //reload field
                loadEmpDetail();
                btnEdit.Text = "Edit";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isSuccess = presenter.UpdateEmpDetail(this);
            if (isSuccess)
            {
                MessageBox.Show(MessageUtil.SAVE_SUCCESS, "Notify");
            }
        }
    }
}
