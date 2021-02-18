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

namespace employee_management_asp_winform.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44329/");
            HttpResponseMessage responseMessage = client.GetAsync("api/employees/find_all").Result;
            var empList = responseMessage.Content.ReadAsStringAsync();
            List<TblEmployeesDTO> data = JsonConvert.DeserializeObject<List<TblEmployeesDTO>>(empList.Result);
            foreach (var emp in data)
            {
                dataGridView1.Rows.Add(emp.empId, emp.fullName, emp.email, emp.phone, emp.status);
            }
        }
    }
}
