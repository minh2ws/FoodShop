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
    public partial class frmCategoryDetail : Form
    {
        private IWarehousePresenter categoryPresenter;
        private bool update = false;
        public frmCategoryDetail()
        {
            InitializeComponent();
        }
        public void setStateUpdate(bool value)
        {
            update = value;
        }
        public bool getStateUpdate()
        {
            return this.update;
        }

        public TextBox getCategoryName()
        {
            return this.txtCategoryName;
        }
        public frmCategoryDetail(bool flag,WarehousePresenter categoryPresenter) : this()
        {
            this.categoryPresenter = categoryPresenter;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            categoryPresenter.saveCategory(this);
        }

        private void frmCategoryDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
