using DTO;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FoodShopManagement_WF.UI
{
    public partial class frmSaleManager_V2 : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        private ISaleManagerPresenter saleManagerPresenter;
        private DataTable dtCustomer;

        public string getCategoryName()
        {
            return this.cmbCategory.Text;
        }

        public string getProductName()
        {
            return this.txtProductName.Text;
        }

        public TextBox getCustomerId()
        {
            return txtCustomerID;
        }

        public TextBox getCustomerName()
        {
            return txtCustomerName;
        }

        public TextBox getCustomerPhone()
        {
            return txtPhonenumber;
        }

        public TextBox getCustomerAddress()
        {
            return txtAddress;
        }

        public frmSaleManager_V2()
        {
            InitializeComponent();
        }
        public frmSaleManager_V2(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            saleManagerPresenter = new SaleManagerPresenter(this);
            this.loginFrame = loginFrame;
            this.emp = emp;
            msTool.Text = "User: " + emp.name;
            loadProducts();
            loadCustomers();
        }

        public void loadProducts()
        {
            //binding data to binding source
            bsProducts.DataSource = saleManagerPresenter.GetProducts();
            dgvProducts.DataSource = bsProducts;
            dgvProducts.Columns["idProduct"].Visible = false;
            dgvProducts.Columns["status"].Visible = false;
            dgvProducts.Columns["idCategory"].Visible = false;
            dgvProducts.Columns["categoryName"].Visible = false;


            //binding to navigation
            bnProducts.BindingSource = bsProducts;

            List<TblCategoryDTO> listCategory = saleManagerPresenter.GetCategories();
            foreach (var category in listCategory)
            {
                cmbCategory.Items.Add(category.name);
            }
        }

        public void loadCustomers()
        {
            dtCustomer = saleManagerPresenter.GetCustomers();

            //binding data to binding source
            bsCustomer.DataSource = dtCustomer;
            dgvCustomer.DataSource = bsCustomer;
            dgvCustomer.Columns["phone"].Visible = false;
            dgvCustomer.Columns["address"].Visible = false;
            dgvCustomer.Columns["point"].Visible = false;


            //binding to navigation
            bnCustomer.BindingSource = bsCustomer;

            //clear binding
            txtCustomerID.DataBindings.Clear();
            txtCustomerName.DataBindings.Clear();
            txtPhonenumber.DataBindings.Clear();
            txtAddress.DataBindings.Clear();
            txtPoint.DataBindings.Clear();

            //binding data to text field
            txtCustomerID.DataBindings.Add("Text", bsCustomer, "idCustomer");
            txtCustomerName.DataBindings.Add("Text", bsCustomer, "name");
            txtPhonenumber.DataBindings.Add("Text", bsCustomer, "phone");
            txtAddress.DataBindings.Add("Text", bsCustomer, "address");
            txtPoint.DataBindings.Add("Text", bsCustomer, "point");
        }
        
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrame.Show();
            Program.TokenGlobal = "";//reset Global token
        }
        private void frmSaleManager_V2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.AddCustomer();
            //loadCustomers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.UpdateCustomer();
            //loadCustomers();
        }

        private void ViewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfileDetailcs ProfileDetail = new frmMyProfileDetailcs(this.emp);
            DialogResult r = ProfileDetail.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //binding data to binding source
            bsProducts.DataSource = saleManagerPresenter.searchProduct(this);
            dgvProducts.DataSource = bsProducts;

            //binding to navigation
            bnProducts.BindingSource = bsProducts;
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            DataView view = dtCustomer.DefaultView;
            string filter = "name like '%" + txtSearchCustomer.Text + "%'";
            view.RowFilter = filter;
        }
    }
}
