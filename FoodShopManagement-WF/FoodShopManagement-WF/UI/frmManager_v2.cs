using DTO;
using System;
using System.Windows.Forms;
using System.Data;
using FoodShopManagement_WF.Presenter;
using FoodShopManagement_WF.Presenter.impl;
using System.Collections.Generic;
using DTO.Model;
using System.Linq;

namespace FoodShopManagement_WF.UI
{
    public partial class frmManager_v2 : Form
    {
        private frmLogin loginFrame;
        private TblEmployeesDTO emp;
        private IManagerDetailPresenter presenter = new ManagerDetailPresenter();
        
        public frmManager_v2(frmLogin loginFrame, TblEmployeesDTO emp)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
            this.emp = emp;
            loadData();
        }
        public void loadData()
        {
            msTool.Text = "User: "+ emp.name;
            //List<LoadEmployeeModel> listEmp = presenter.loadData(this);
            List<TblEmployeesDTO> listEmp = presenter.loadEmployeeDTO(this);
            //dgvListEmployee.DataSource = listEmp;

            dgvListEmployee.DataSource = listEmp.Select(emp => new {
            Id = emp.idEmployee, Name = emp.name }).ToList();
        }

        private void frmManager_v2_Load(object sender, EventArgs e)
        {

        }

        private void frmManager_v2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrame.Show();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEmployeeDetail ProductDetail = new frmEmployeeDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Tao moi doi tuong va truyen tham so cho Form frmProductDetails ( true la them moi) 
            frmEmployeeDetail ProductDetail = new frmEmployeeDetail(true);
            DialogResult r = ProductDetail.ShowDialog();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void ViewProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMyProfileDetailcs ProductDetail = new frmMyProfileDetailcs(this.emp);
            DialogResult r = ProductDetail.ShowDialog();
        }

        private string role;//var to load emp base on role
        public string getRole()
        {
            return this.cbRole.Text;
        }

        public void setRole(string role)
        {
            this.role = role;
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            setRole(cbRole.SelectedIndex.ToString());
            loadData();
        }
    }
}
