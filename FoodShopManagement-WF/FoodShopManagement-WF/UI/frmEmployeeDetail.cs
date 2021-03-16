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
        IManagerDetailPresenter ManagerDetailPresenter = new ManagerDetailPresenter();
       
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
        public frmEmployeeDetail(bool flag): this()        {
          


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD

            bool Insert = ManagerDetailPresenter.InsertEmployee(this);
            if (!Insert)

=======
            bool Insert = ManagerDetailPresenter.InsertEmployee(this);
            if (!Insert)
>>>>>>> cd3cf57e41c0e067733b9a1657ec5ca0a2d33157
            {
                MessageBox.Show("invalid password or id", "Warning!");
            }
            else MessageBox.Show("Successful Insert ");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
