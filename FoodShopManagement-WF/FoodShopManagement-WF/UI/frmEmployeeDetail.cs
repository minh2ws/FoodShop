using DTO;
using FoodShopManagement_WF.Util;
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

namespace FoodShopManagement_WF.UI
{
    public partial class frmEmployeeDetail : Form
    {
       public  TblEmployeesDTO Employees;
        public frmEmployeeDetail() 
        {
            InitializeComponent();
            
            
        }
        public frmEmployeeDetail(bool flag): this()        {
          


        }
        private void btnSave_Click(object sender, EventArgs e)
        {
             Employees.idEmployee = txtEmployeeID.Text.Trim();
            Employees.name = txtFullName.Text.Trim();
            Employees.password = txtPassword.Text.Trim();
            Employees.role = cbRole.GetItemText(this.cbRole.SelectedItem);
            Employees.status = true;

            
            HttpResponseMessage responseMessage = ApiConnection.loadPostJsonObject("Employee/Insert", Employees);
            if (responseMessage.StatusCode != System.Net.HttpStatusCode.Unauthorized)
            {
                var result = responseMessage.Content.ReadAsStringAsync();
                bool emp = JsonConvert.DeserializeObject<Boolean>(result.Result);
              
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
