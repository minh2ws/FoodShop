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
    public partial class frmSaleManager : Form
    {
        public frmLogin loginFrame;


        public frmSaleManager()
        {
            InitializeComponent();
        }
        public frmSaleManager(frmLogin loginFrame)
        {
            InitializeComponent();
            this.loginFrame = loginFrame;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            loginFrame.Show();
        }

        private void frmSaleManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
