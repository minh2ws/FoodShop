using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShopManagement_WF.Presenter.impl
{
    public class MyProfileDetailPresenter : IMyProfileDetailPresenter
    {
        IMyProfileDetailModel model = new MyProfileDetailModel();
        
        public bool checkField(TblEmployeesDTO emp)
        {
            if (emp.name.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Name can't empty!!", "Error");
                return false;
            }

            if (emp.password.Trim().Length == 0)
            {
                System.Windows.Forms.MessageBox.Show("Password can't empty!!", "Error");
                return false;
            }
            return true;
        }
        public bool UpdateEmpDetail(frmMyProfileDetailcs form)
        {
            TblEmployeesDTO emp = new TblEmployeesDTO {
                name = form.getTxtName(),
                password = form.getTxtPassword(),
            };
            bool isSuccess = checkField(emp);
            if (isSuccess)
            {
                return model.UpdateEmpDetail(emp);//return true if update sucess
            }
            return false;
        }
    }
}
