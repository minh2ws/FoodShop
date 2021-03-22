using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using FoodShopManagement_WF.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter.impl
{
    class LoginPresenter : ILoginPresenter
    {
        ILoginModel loginModel = new LoginModel();
        public bool checkLogin(frmLogin form)
        {
            string username = form.getUserName().Trim();
            string password = form.getPassword().Trim();
            TblEmployeesDTO tblEmployeesDTO = new TblEmployeesDTO();
            tblEmployeesDTO.idEmployee = username;
            tblEmployeesDTO.password = password;
            TblEmployeesDTO emp =loginModel.checkLogin(tblEmployeesDTO);
            
            if (emp!=null)
            {
                string role = emp.role.ToUpper();
                switch (role)
                {
                    case "MANAGER":
                        frmManager_v2 manager = new frmManager_v2(form,emp);
                        manager.Show();
                        break;
                    case "WAREHOUSE STAFF":
                        frmWarehouse_V2 warehouse = new frmWarehouse_V2(form, emp);
                        warehouse.Show();
                        break;
                    case "SALESMAN":
                        frmSaleManager_V2 saleManager = new frmSaleManager_V2(form, emp);
                        saleManager.Show();
                        break;
                }
                form.Hide();
                form.setUsername("");
                form.setPassword("");
                return true;
            }
            return false;
        }
    }
}
