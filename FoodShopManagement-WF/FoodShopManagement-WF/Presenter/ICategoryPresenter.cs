using DTO;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter
{
    interface ICategoryPresenter
    {
        void getAll();
        void save(frmCategoryDetail frmCategoryDetail);
        void edit();
        void add();
        void search();
    }
}
