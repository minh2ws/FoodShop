using DTO;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodShopManagement_WF.UI
{
    public partial class frmSaleManager_V2 : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        private ISaleManagerPresenter saleManagerPresenter = new SaleManagerPresenter();

        public string getCategoryName()
        {
            return this.cmbCategory.Text;
        }

        public string getProductName()
        {
            return this.txtProductName.Text;
        }
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

            //binding data to binding source
            bsProducts.DataSource = saleManagerPresenter.GetProducts();
            dgvProducts.DataSource = bsProducts;

            //binding to navigation
            bnProducts.BindingSource = bsProducts;

            List<TblCategoryDTO> listCategory = saleManagerPresenter.GetCategories();
            foreach (var category in listCategory)
            {
                cmbCategory.Items.Add(category.name);
            }
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //binding data to binding source
            bsProducts.DataSource = saleManagerPresenter.searchProduct(this);
            dgvProducts.DataSource = bsProducts;

            //binding to navigation
            bnProducts.BindingSource = bsProducts;
        }
    }
}
