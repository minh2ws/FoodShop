using DTO;
using System;
using System.Windows.Forms;


namespace FoodShopManagement_WF.UI
{
    public partial class frmSaleManager : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;

        public frmSaleManager()
        {
            InitializeComponent();
        }
        public frmSaleManager(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
            this.emp = emp;
            loadData();
        }

        public void loadData()
        {
            lbWelcome.Text = "Welcome, " + emp.name;

        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrame.Show();
        }

        private void frmSaleManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
