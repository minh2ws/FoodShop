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
    public partial class frmProductDetail : Form
    {
        private bool update = false;
        private IWarehousePresenter warehousePresenter;
        public bool getUpdateState()
        {
            return this.update;
        }
        public void setUpdateState(bool value)
        {
            this.update = value;
        }
        public TextBox getProductName()
        {
            return txtProductName;
        }
        public RadioButton getRadioButtonTrue()
        {
            return rdoStatusTrue;
        }
        public RadioButton getRadioButtonFalse()
        {
            return rdoStatusFalse;
        }

        public TextBox getPrice()
        {
            return txtUnitPrice;
        }

        public TextBox getQuantity()
        {
            return txtQuantity;
        }

        public ComboBox getComboBoxCategory()
        {
            return cbCategory;
        }

        public frmProductDetail()
        {
            InitializeComponent();
        }
        public frmProductDetail(bool flag, WarehousePresenter warehousePresenter) : this()
        {
            this.warehousePresenter = warehousePresenter;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            warehousePresenter.saveProduct(this);
            
        }

        private void frmProductDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmProductDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
