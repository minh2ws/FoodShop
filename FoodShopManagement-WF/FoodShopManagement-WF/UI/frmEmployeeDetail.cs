using DTO;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using FoodShopManagement_WF.Util;
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
        IEmployeePresenter presenter;
        private bool flag = false; //khai báo biến cờ để check event
        public bool getIsUpdate()
        {
            return this.flag;
        }
        public void setIsUpdate(bool value)
        {
            this.flag = value;
        }
        public string getUserName()
        {
            return this.txtEmployeeID.Text;
        }
        public string getPassword()
        {
            return this.txtPassword.Text;
        }
        public string getFullName()
        {
            return this.txtFullName.Text;
        }
        public string getRole()
        {
            return this.cbRole.GetItemText(this.cbRole.SelectedItem);
        }
        public string getStatus()
        {
            return this.cbStatus.GetItemText(this.cbStatus.SelectedItem);
        }
        public void setUsername(string username)
        {
            this.txtEmployeeID.Text = username;
        }
        public void setPassword(string password)
        {
            this.txtPassword.Text = password;
        }
        public void setFullname(string fullname)
        {
            this.txtFullName.Text = fullname;
        }
        public void setRole(string Role)
        {
            this.cbRole.Items.Add(Role);
        }
        public frmEmployeeDetail() 
        {
            InitializeComponent();
            
            
        }
        public frmEmployeeDetail(bool flag, EmployeePresenter presenter): this()        {
            this.presenter = presenter;


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flag == true)
            {
                presenter.InsertEmployee();
            }
            else
            {

            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
