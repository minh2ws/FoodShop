using DTO;
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
    public partial class frmWarehouse_V2 : Form
    {

        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        public frmWarehouse_V2()
        {
            InitializeComponent();
        }
        public frmWarehouse_V2(frmLogin loginFrame, TblEmployeesDTO emp)
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
        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            frmCategoryDetail ProductDetail = new frmCategoryDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrame.Show();
        }

        private void frmWarehouse_V2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {

            frmCategoryDetail ProductDetail = new frmCategoryDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {

            frmProductDetail ProductDetail = new frmProductDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {

            frmProductDetail ProductDetail = new frmProductDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void ViewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(true);
            DialogResult r = ProductDetail.ShowDialog();
        }
    }
}
