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
    public partial class frmProductDetail : Form
    {
        public TextBox getIdProduct()
        {
            return txtProductID;
        }

        public TextBox getProductName()
        {
            return txtProductName;
        }

        public TextBox getPrice()
        {
            return txtUnitPrice;
        }

        public TextBox getQuantity()
        {
            return txtQuantity;
        }

        public ComboBox getIdCategory()
        {
            return cbCategory;
        }

        public frmProductDetail()
        {
            InitializeComponent();
        }
        public frmProductDetail(bool flag) : this()
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
