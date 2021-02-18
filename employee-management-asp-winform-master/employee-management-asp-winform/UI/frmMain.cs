using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using employee_management_asp_winform.DTO;
using Newtonsoft.Json;

namespace employee_management_asp_winform
{
    public partial class MainFrame : Form
    {
        
        public MainFrame()
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44329/");
            HttpResponseMessage responseMessage = client.GetAsync("api/employees/find_all").Result;
            var empList = responseMessage.Content.ReadAsStringAsync();
            List<EmployeeDTO> data = JsonConvert.DeserializeObject<List<EmployeeDTO>>(empList.Result);
            foreach (var emp in data)
            {
                dataGridView1.Rows.Add(emp.empId, emp.fullName, emp.email, emp.phone, emp.status);
            }
        }

        private void btnFindAll_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44329/");
            HttpResponseMessage responseMessage = client.GetAsync("api/employees/find_all").Result;
            var empList = responseMessage.Content.ReadAsStringAsync();
            List<EmployeeDTO> data =JsonConvert.DeserializeObject<List<EmployeeDTO>>(empList.Result);
            foreach (var emp in data)
            {
                dataGridView1.Rows.Add(emp.empId,emp.fullName,emp.email,emp.phone,emp.status);
            }
            
        }
        
    }
}
