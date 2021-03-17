using DTO;
using System;
using System.Windows.Forms;
using System.Data;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using System.Collections.Generic;
using DTO.Model;
using System.Linq;

namespace FoodShopManagement_WF.UI
{
    public partial class frmManager_v2 : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        private IManagerDetailPresenter presenter = new ManagerDetailPresenter();
        
        public frmManager_v2(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
            this.emp = emp;
            loadData();
        }
        public void loadData()
        {
            msTool.Text = "User: "+ emp.name;
            //List<LoadEmployeeModel> listEmp = presenter.loadData(this);
            List<TblEmployeesDTO> listEmp = presenter.loadEmployeeDTO(this);
            //dgvListEmployee.DataSource = listEmp;

            dgvListEmployee.DataSource = listEmp.Select(emp => new {
            Id = emp.idEmployee, Name = emp.name,
                Password = emp.password,
                Role = emp.role
            }).ToList();
             
        }

        private void frmManager_v2_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void frmManager_v2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }



        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrame.Show();
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEmployeeDetail ProductDetail = new frmEmployeeDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmployeeDetail ProductDetail = new frmEmployeeDetail(true);
            DialogResult r = ProductDetail.ShowDialog();
           

        }

        private void ViewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(this.emp);
            DialogResult r = ProductDetail.ShowDialog();

        }
        private string role;//var to load emp base on role
        public string getRole()
        {
            return this.cbRole.Text;
        }

        public void setRole(string role)
        {
            this.role = role;
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRole(cbRole.SelectedIndex.ToString());
            loadData();
        }

        private void dgvListEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtEmployeeID.Text = dgvListEmployee.SelectedRows[0].Cells[0].Value.ToString();
                txtFullname.Text = dgvListEmployee.SelectedRows[0].Cells[1].Value.ToString();
                txtPassword.Text = dgvListEmployee.SelectedRows[0].Cells[2].Value.ToString();
                txtRole.Text = dgvListEmployee.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id=dgvListEmployee.SelectedRows[0].Cells[0].Value.ToString();

            bool delete = presenter.DeleteEmployee(id);
        }
    }
}
