using DTO;
using System;
using System.Windows.Forms;
using System.Data;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using System.Collections.Generic;
using System.Linq;

namespace FoodShopManagement_WF.UI
{
    public partial class frmManager_v2 : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        private IManagerDetailPresenter presenter;
        
        public frmManager_v2(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
            this.emp = emp;
            presenter = new ManagerDetailPresenter(this);
            txtEmployeeID.Enabled=true;
            txtFullname.Enabled = true;
            txtPassword.Enabled = true;
            txtRole.Enabled = true;
            txtStatus.Enabled = false;
        }

        public TextBox getIdEmp()
        {
            return txtEmployeeID;
        }
        public TextBox getEmpName()
        {
            return txtFullname;
        }
        public TextBox getPassword()
        {
            return txtPassword;
        }

        public void loadData()
        {
            msTool.Text = "User: "+ emp.name;
           
            dgvListEmployee.ColumnCount = 2;
            dgvListEmployee.Columns[0].Name = "ID";
            dgvListEmployee.Columns[0].DataPropertyName = "idEmployee";
            dgvListEmployee.Columns[1].Name = "Name";
            dgvListEmployee.Columns[1].DataPropertyName = "name";
            dgvListEmployee.AutoGenerateColumns = false;
            presenter.loadEmp();
        }
        public void loadAll()
        {
            msTool.Text = "User: " + emp.name;
            presenter.loadEmp();
        }
        public void loadEmpByRole()
        {
            msTool.Text = "User: " + emp.name;
            presenter.LoadEmpByRole(this);

        }
        public DataGridView GetDataGridViewEmployee()
        {
            return this.dgvListEmployee;
        }
        public BindingNavigator GetBindingNavigator()
        {
            return this.bnEmployee;
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
            string role = getRole();
            if (role.Equals("All"))
            {
                loadAll();
            }
            else
            {
                loadEmpByRole();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id=dgvListEmployee.SelectedRows[0].Cells[0].Value.ToString();

            bool delete = presenter.DeleteEmployee(id);
        }
    }
}
