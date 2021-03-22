using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.UI
{
    public partial class frmEmployeeDetail : Form
    {
<<<<<<< HEAD
        private bool flag = false;
        private IEmployeePresenter presenter;
        public bool getFlag()
=======
        IEmployeePresenter ManagerDetailPresenter = new EmployeePresenter();
       
        public string getUserName()
>>>>>>> ab954045bfaee2e036f5bc8c03efead4cdf0cc1b
        {
            return this.flag;
        }
        public void setFlag(bool flag)
        {
            this.flag = flag;
        }
        public TextBox getUserName()
        {
            return this.txtEmployeeID;
        }
        public TextBox getPassword()
        {
            return this.txtPassword;
        }
        public TextBox getFullName()
        {
            return this.txtFullName;
        }
        private string role;
        public string getRole()
        {
            return this.cbRole.Text;
        }
        public void setRole(string role)
        {
            this.role = role;
        }
        public string getEmpRole()
        {
            setRole(cbRole.SelectedIndex.ToString());
            string role = getRole();
            return role;
        }
        public ComboBox GetComboBoxStatus()
        {
            return cbStatus;
        }

        public frmEmployeeDetail() 
        {
            InitializeComponent();
        }

        public frmEmployeeDetail(bool flag, EmployeePresenter presenter): this()
        {
            this.presenter = presenter; 
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
           
         
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRole(cbRole.SelectedIndex.ToString());
            string role = getRole();
        }
    }
}
