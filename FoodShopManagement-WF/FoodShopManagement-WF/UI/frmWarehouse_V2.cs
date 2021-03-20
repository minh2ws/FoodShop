using DTO;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using System;
using System.Windows.Forms;

namespace FoodShopManagement_WF.UI
{
    public partial class frmWarehouse_V2 : Form
    {

        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        private ICategoryPresenter categoryPresenter;
        public frmWarehouse_V2()
        {
            InitializeComponent();
        }
        public TextBox getIdCategory()
        {
            return txtCategoryID;
        }
        public TextBox getNameCategory()
        {
            return txtCategoryName;
        }
        public frmWarehouse_V2(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
            this.emp = emp;
            categoryPresenter = new CategoryPresenter(this);
        }
        public BindingNavigator GetBindingNavigatorCategory()
        {
            return this.bindingNavigatorCategory;
        }
        
        
        public DataGridView GetDataGridViewCategory()
        {
            return this.dtgCategories;
        }
        public void loadData()
        {
            msTool.Text = "User: " + emp.name;
            categoryPresenter.getAll();
            
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {

            categoryPresenter.add();

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

            categoryPresenter.edit();
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
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(this.emp);
            DialogResult r = ProductDetail.ShowDialog();
        }

        private void frmWarehouse_V2_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public ToolStripTextBox getSearchCategoryBox()
        {
            return this.txtSearchCategory;
        }
        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            categoryPresenter.search();
        }
       
    }
}
