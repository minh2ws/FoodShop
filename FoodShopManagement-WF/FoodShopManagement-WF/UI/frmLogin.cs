using FoodShopManagement_WF.DTO;
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
using Newtonsoft.Json;

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
            String json=JsonConvert.SerializeObject(tblEmployeesDTO);
            StringContent data = new StringContent(json,Encoding.UTF8,"application/json");
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44314/");
            HttpResponseMessage responseMessage= httpClient.PostAsync("api/FoodShopManagement/login", data).Result;
            Console.WriteLine(responseMessage.StatusCode);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var employeeDTO = responseMessage.Content.ReadAsStringAsync();
                TblEmployeesDTO emp=JsonConvert.DeserializeObject<TblEmployeesDTO>(employeeDTO.Result);
                label4.Text = "login successfull";
            }
            else
            {
                label4.Text = "invalid password or id";
            }
        }

       
    }
}
