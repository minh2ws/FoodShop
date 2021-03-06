using DTO;
using System;
using System.Windows.Forms;

namespace FoodShopManagement_WF.UI
{
    public partial class frmManager : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        public frmManager()
        {
            InitializeComponent();
        }
        public frmManager(frmLogin loginFrame, TblEmployeesDTO emp)
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

        private void frmManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmManager_Load(object sender, EventArgs e)
        {

        }
    }
}
