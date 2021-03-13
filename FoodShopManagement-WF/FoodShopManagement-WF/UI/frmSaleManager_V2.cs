using DTO;
using System;
using System.Windows.Forms;

namespace FoodShopManagement_WF.UI
{
    public partial class frmSaleManager_V2 : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        public frmSaleManager_V2()
        {
            InitializeComponent();
        }
        public frmSaleManager_V2(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
            this.emp = emp;
            loadData();
        }
        public void loadData()
        {
            msTool.Text = "User: " + emp.name;

        }
        
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrame.Show();
        }
        private void frmSaleManager_V2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCustomerDetail ProductDetail = new frmCustomerDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            frmCustomerDetail ProductDetail = new frmCustomerDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void ViewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(true);
            DialogResult r = ProductDetail.ShowDialog();
        }
    }
}
