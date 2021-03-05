using FoodShopManagement_WF.DTO;
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
    public partial class frmWarehouse : Form
    {
        private frmLogin formLogin;
        private TblEmployeesDTO emp;
        public frmWarehouse()
        {
            InitializeComponent();
        }
        public frmWarehouse(frmLogin formLogin,TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.formLogin = formLogin;
            this.emp = emp;
            loadData();
        }
        public void loadData()
        {
            lblWelcome.Text = "Welcome, " + emp.name;

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            formLogin.Show();
        }

        private void frmWarehouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
