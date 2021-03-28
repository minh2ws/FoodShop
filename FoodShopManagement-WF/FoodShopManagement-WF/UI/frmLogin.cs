using System;
using System.Windows.Forms;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;

namespace FoodShopManagement_WF
{
    public partial class frmLogin : Form
    {
        ILoginPresenter loginPresenter = new LoginPresenter();
        public frmLogin()
        {
            InitializeComponent();
        }
        public string getUserName()
        {
            return this.txtUsername.Text;
        }
        public string getPassword()
        {
            return this.txtPassword.Text;
        }
        public void setUsername(string username)
        {
            this.txtUsername.Text = username;
        }
        public void setPassword(string password)
        {
            this.txtPassword.Text = password;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool checkLogin = loginPresenter.checkLogin(this);
            if (!checkLogin)
            {
                MessageBox.Show("invalid password or id", "Warning!");
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
