using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
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
    public partial class frmCustomerDetail : Form
    {
        private ISaleManagerPresenter presenter;
        private bool addNew;
        private string customerId;

        public bool isAddNew()
        {
            return addNew;
        }

        public string getCustomerID()
        {
            return customerId;
        }

        public void setCustomerId(string customerId)
        {
            this.customerId = customerId;
        }

        public TextBox getCustomerName()
        {
            return txtCustomerName;
        }

        public TextBox getCustomerPhone()
        {
            return txtPhonenumber;
        }

        public TextBox getAddress()
        {
            return txtAddress;
        }

        public frmCustomerDetail()
        {
            InitializeComponent();
        }

        public frmCustomerDetail(bool isAddNew, frmSaleManager_V2 frmSaleManager)
        {
            InitializeComponent();
            presenter = new SaleManagerPresenter(frmSaleManager);
            this.addNew = isAddNew;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            presenter.SaveCustomer(this);
        }

        private void frmCustomerDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
