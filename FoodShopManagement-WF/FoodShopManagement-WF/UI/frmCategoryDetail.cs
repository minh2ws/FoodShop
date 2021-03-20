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
        public frmCategoryDetail()
        {
            InitializeComponent();
        }
 
        public TextBox getCategoryId()
        {
            return this.txtCategoryID;
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
    }
}
