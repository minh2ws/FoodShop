using FoodShopManagement_WF.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task btnLogin_ClickAsync(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            TblEmployeesDTO dto = new TblEmployeesDTO();
            dto.idEmployee = username;
            dto.password = password;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44314/");
            var json = JsonConvert.SerializeObject(dto);
            //HttpResponseMessage responseMessage
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            var result = await client.PostAsync("api/FoodShopManagement/login", data);
            
            var empResult = result.Content.ReadAsStringAsync();
            TblEmployeesDTO emp = JsonConvert.DeserializeObject<TblEmployeesDTO>(empResult.Result);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            TblEmployeesDTO dto = new TblEmployeesDTO();
            dto.idEmployee = username;
            dto.password = password;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44314/");
            var json = JsonConvert.SerializeObject(dto);
            //HttpResponseMessage responseMessage
            StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage result = client.PostAsync("api/FoodShopManagement/login", data);

            var empResult = result.Content.ReadAsStringAsync().Result;
            TblEmployeesDTO emp = JsonConvert.DeserializeObject<TblEmployeesDTO>(empResult.Result);
        }
    }
}
