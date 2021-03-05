using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter
{
    interface ILoginPresenter
    {
         bool checkLogin(frmLogin form);
    }
}
