using DTO;
using System;
using System.Windows.Forms;
using System.Data;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using System.Collections.Generic;
using System.Linq;
using DevExpress.DirectX.Common.DirectWrite;

namespace FoodShopManagement_WF.UI
{
    public partial class frmManager_v2 : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        private IEmployeePresenter presenter;

        public frmManager_v2(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
            this.emp = emp;
            presenter = new EmployeePresenter(this);

            txtEmployeeID.Enabled=false;
            txtFullname.Enabled = false;
            txtPassword.Enabled = false;
            txtRole.Enabled = false;
            txtStatus.Enabled = false;
            dgvListEmployee.ReadOnly = true;
            loadAll();
        }

        //get Textbox Data
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
        public TextBox getEmpRole()
        {
            return txtRole;
        }
        public TextBox getStatus()
        {
            return txtStatus;
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
      
        public void loadData()
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
            loadAll();
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

        public TblEmployeesDTO getEmp()
        {
            TblEmployeesDTO emp = new TblEmployeesDTO
            {
                idEmployee = getID(),
                name = getName(),
                password = getEmpPass(),
                role = getRole(),
                status = bool.Parse(getEmpStatus())
            };
            return emp;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            presenter.UpdateEmployee();
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            presenter.InsertEmployee();
            loadData();

        }
  
     
        private void ViewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(this.emp);
            DialogResult r = ProductDetail.ShowDialog();

        }
        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRole(cbRole.SelectedIndex.ToString());
            string role = getRole();
            loadData();
        }
        //lấy dữ liệu từ textbox đang có trên datagridview
        private string idEmp;
        private string EmpName;
        private string EmpPassword;
        private string role;//var to load emp base on role
        private string EmpStatus;
        public string getID()
        {
            return this.txtEmployeeID.Text;
        }
        public void setID(string idEmp)
        {

            this.idEmp = idEmp;
        }
        public string getName()
        {
            return this.txtFullname.Text;
        }
        public void setName(string name)
        {
            this.EmpName = name;
        }
        public string getEmpPass()
        {
            return this.txtPassword.Text;
        }
        public void setEmpPass(string password)
        {
            this.EmpPassword = password;
        }
        public string getRole()
        {
            return this.cbRole.Text;
        }
        public void setRole(string role)
        {
            this.role = role;
        }
        public string getEmpStatus()
        {
            return this.txtStatus.Text;
        }
        public void setEmpStatus(string status)
        {
            this.EmpStatus = status;
        }
        public ToolStripTextBox getSearchEmpBox()
        {
            return this.txtSearchEmp;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            setID(txtEmployeeID.Text);
            string id = getID();
            presenter.DeleteEmployee(this);
            setRole(cbRole.SelectedIndex.ToString());
            string role = getRole();
            loadData();
        }


      

        private void txtEmpSearch_TextChanged(object sender, EventArgs e)

        {
            presenter.searchEmployee();
        }
    }
}
