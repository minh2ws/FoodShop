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
        private ISaleManagerPresenter saleManagerPresenter = new SaleManagerPresenter();
        private DataTable dtCustomer;

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
            msTool.Text = "User: " + emp.name;
            loadProducts();
            loadCustomers();
        }

        public void loadProducts()
        {
            //customize datagridview
            dgvProducts.ColumnCount = 3;
            dgvProducts.Columns[0].Name = "Name";
            dgvProducts.Columns[0].DataPropertyName = "name";
            dgvProducts.Columns[1].Name = "Price";
            dgvProducts.Columns[1].DataPropertyName = "price";
            dgvProducts.Columns[2].Name = "Quantity";
            dgvProducts.Columns[2].DataPropertyName = "quantity";

            dgvProducts.AutoGenerateColumns = false;


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

        public void loadCustomers()
        {
            dtCustomer = saleManagerPresenter.GetCustomers();
            
            //customize datagridview
            dgvCustomer.ColumnCount = 2;
            dgvCustomer.Columns[0].Name = "CustomerID";
            dgvCustomer.Columns[0].DataPropertyName = "idCustomer";
            dgvCustomer.Columns[1].Name = "Customer Name";
            dgvCustomer.Columns[1].DataPropertyName = "name";

            dgvCustomer.AutoGenerateColumns = false;

            //binding data to binding source
            bsCustomer.DataSource = dtCustomer;
            dgvCustomer.DataSource = bsCustomer;

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
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(this.emp);
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

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            DataView view = dtCustomer.DefaultView;
            string filter = "name like '%" + txtSearchCustomer.Text + "%'";
            view.RowFilter = filter;
        }
    }
}
