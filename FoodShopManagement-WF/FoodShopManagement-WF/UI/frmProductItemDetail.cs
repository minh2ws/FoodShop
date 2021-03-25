using DTO;
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
    public partial class frmProductItemDetail : Form
    {
        private TblEmployeesDTO emp;

        public frmProductItemDetail()
        {
            InitializeComponent();
        }

        public frmProductItemDetail(TblEmployeesDTO emp, CartItemDTO item)
        {
            InitializeComponent();
            this.emp = emp;
        }

        public TextBox getItemQuantity()
        {
            return this.txtQuantity;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
