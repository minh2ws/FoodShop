using FoodShopManagement_WF.DTO;
using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using FoodShopManagement_WF.Util;
using FoodShopManagement_WF.UI;

namespace FoodShopManagement_WF
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            TblEmployeesDTO tblEmployeesDTO = new TblEmployeesDTO();
            tblEmployeesDTO.idEmployee = username;
            tblEmployeesDTO.password = password;
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("login", tblEmployeesDTO);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var employeeDTO = responseMessage.Content.ReadAsStringAsync();
                TblEmployeesDTO emp=JsonConvert.DeserializeObject<TblEmployeesDTO>(employeeDTO.Result);
                string role = emp.role;
                switch (role)
                {
                    case "MANAGER":
                        frmManager_v2 manager = new frmManager_v2(this, emp);
                        manager.Show();
                        break;
                    case "STAFF":
                        frmWarehouse warehouse = new frmWarehouse();
                        warehouse.Show();
                        break;
                    case "SALESMAN":
                        frmSaleManager_V2 saleManager = new frmSaleManager_V2(this, emp);
                        saleManager.Show();
                        break;
                }
                Hide();
                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("invalid password or id", "Warning!");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
    }
}
