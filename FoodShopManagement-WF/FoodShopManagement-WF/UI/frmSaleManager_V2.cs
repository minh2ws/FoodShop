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

        public TblEmployeesDTO getEmployee()
        {
            return this.emp;
        }
        public ComboBox getCmbCategory()
        {
            return this.cmbCategory;
        }
        public TextBox getProductName()
        {
            return this.txtProductName;
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
        public TextBox getCustomerPoint()
        {
            return this.txtPoint;
        }
        public DataGridView getDgvProduct()
        {
            return this.dgvProducts;
        }
        public DataGridView getDgvCustomer()
        {
            return this.dgvCustomer;
        }
        public DataGridView getDgvItemOfOrder()
        {
            return this.dgvItemOfOrder;
        }
        public BindingSource getBindingSourceProduct()
        {
            return this.bsProducts;
        }
        public BindingSource getBindingSourceCustomer()
        {
            return this.bsCustomer;
        }
        public BindingNavigator getBnProduct()
        {
            return this.bnProducts;
        }
        public BindingNavigator getBnCustomer()
        {
            return this.bnCustomer;
        }
        public TextBox getSearchCustomer()
        {
            return this.txtSearchCustomer;
        }
        public TextBox getCustomerOrder()
        {
            return this.txtCustomerOrder;
        }
        public TextBox getAmount()
        {
            return this.txtAmount;
        }
        public TextBox getDiscount()
        {
            return this.txtDiscount;
        }
        public TextBox getCurrentAmount()
        {
            return this.txtCurrentAmount;
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
            saleManagerPresenter.LoadProducts();
            saleManagerPresenter.LoadCustomers();
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
            if (r == DialogResult.OK)
            {

                if (MessageBox.Show("Do you want to logout?", "Confirmation", MessageBoxButtons.YesNo)
                  == DialogResult.Yes)
                {
                    this.Hide();
                    loginFrame.Show();
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.SearchProduct();
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.SearchCustomer();
        }

        private void btnAddtocart_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.AddProductToOrder();
            saleManagerPresenter.LoadProductsOrder();
            saleManagerPresenter.UpdateAmount();
            saleManagerPresenter.UpdateCurrentAmount();
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.RemoveProductFromOrder();
            saleManagerPresenter.LoadProductsOrder();
            saleManagerPresenter.UpdateAmount();
            saleManagerPresenter.UpdateCurrentAmount();
        }

        private void btnGetCustomer_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.GetCustomerInfo();
            saleManagerPresenter.UpdateCurrentAmount();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.CheckoutCart();
        }

        private void btnUpdateCart_Click(object sender, EventArgs e)
        {
            saleManagerPresenter.UpdateQuantityOfItem();
            saleManagerPresenter.LoadProductsOrder();
            saleManagerPresenter.UpdateAmount();
            saleManagerPresenter.UpdateCurrentAmount();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            saleManagerPresenter.UpdateCurrentAmount();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            saleManagerPresenter.GetCustomerInfo();
            saleManagerPresenter.UpdateCurrentAmount();
        }
    }
}
