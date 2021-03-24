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
            txtCustomerID.Enabled = false;
            txtCustomerName.Enabled = false;
            txtAddress.Enabled = false;
            txtPoint.Enabled = false;
            txtPoint.Enabled = false;
            txtPhonenumber.Enabled = false;
            dgvCustomer.ReadOnly = true;
            loadAll();
            presenter.LoadCustomers();
            presenter.LoadRevenues(datetimepicker.Value);
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
        public TextBox getproductname()
        {
            return txtproductname;
        }
        public TextBox getcustomer()
        {
            return txtcustomer;
        }
        public TextBox getprice()
        {
            return txtPrice;
        }
        public TextBox getquantity()
        {
            return txtQuantity;
        }
        public TextBox gettotal()
        {
            return txttotal;
        }
        
        public TextBox getsalesman()
        {
            return txtsalesman;
        }
        public DateTime getDate()
        {
            return datetimepicker.Value;
        }
        public TextBox getStatus()
        {
            return txtStatus;
        }
        public void setmsTool(TblEmployeesDTO emp)
        {
            this.emp = emp;
            msTool.Text = "User: " + emp.name;
        }
        public void loadAll()
        {
            msTool.Text = "User: " + emp.name;
            presenter.loadEmp();
        }
        public TextBox getCustomerId()
        {
            return txtCustomerID;
        }
        public TextBox getCustomerName()
        {
            return txtCustomerName;
        }
        public TextBox getCustomerPhone()
        {
            return txtPhonenumber;
        }
        public TextBox getCustomerAddress()
        {
            return txtAddress;
        }
        public TextBox getCustomerPoint()
        {
            return this.txtPoint;
        }
        public DataGridView getDgvCustomer()
        {
            return this.dgvCustomer;
        }
        public BindingNavigator getBnCustomer()
        {
            return this.bnCustomer;
        }
        public ToolStripTextBox getSearchCustomer()
        {
            return this.txtSearchCustomer;
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
        public DataGridView getDgvOrderDetail()
        {
            return this.dgrOrderDetail;
        }
        public BindingNavigator getBnOrderDetail()
        {
            return this.bnOrderDetail;
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
        private void btnEdit_Click(object sender, EventArgs e)
        {
            presenter.updateEmp();
            loadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            presenter.InsertEmployee();
            loadData();

        }
        public ToolStripTextBox getSearchEmpBox()
        {
            return this.txtEmpSearch;
        }
     
        private void ViewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(this.emp);
            DialogResult r = ProductDetail.ShowDialog();
            if (r == DialogResult.OK)
            {
               
                if (MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButtons.YesNo)
                  == DialogResult.Yes)
                {
                    this.Hide();
                    loginFrame.Show();
                }
            }

        }
        private string role;//var to load emp base on role
        public string getRole()
        {
            return this.cbRole.Text;
        }
        public string getRoletext()
        {
            return this.txtRole.Text;
        }

        public void setRole(string role)
        {
            this.role = role;
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRole(cbRole.SelectedIndex.ToString());
            string role = getRole();
            loadData();
        }

        private string idEmp;
        public string getID()
        {
            return this.txtEmployeeID.Text;
        }
        public void setID(string idEmp)
        {

            this.idEmp = idEmp;
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

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            presenter.SearchCustomer();
        }

      

       

        

        private void SearchDate(object sender, EventArgs e)
        {
            presenter.LoadRevenues(datetimepicker.Value);
        }

        
    }
}
