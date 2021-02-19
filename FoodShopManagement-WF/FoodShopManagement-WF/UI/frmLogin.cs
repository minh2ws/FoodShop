using FoodShopManagement_WF.DTO;
using System;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using FoodShopManagement_WF.Util;
using FoodShopManagement_WF.UI;

namespace FoodShopManagement_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
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
                        frmManager manager = new frmManager();
                        manager.Show();
                        break;
                    case "STAFF":
                        frmWarehouse warehouse = new frmWarehouse();
                        warehouse.Show();
                        break;
                    case "SALESMAN":
                        frmSaleManager saleManager = new frmSaleManager();
                        saleManager.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("invalid password or id", "Warning!");
            }
        }

       
    }
}
