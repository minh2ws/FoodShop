using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter.impl
{
    class CategoryPresenter : ICategoryPresenter
    {
        private ICategoryModel categoryModel = new CategoryModel();
        private frmWarehouse_V2 form;
        public CategoryPresenter (frmWarehouse_V2 form)
        {
            this.form = form;
        }
        public void getAll()
        {
            List<TblCategoryDTO> categoryDTOs= categoryModel.getAll();
            BindingSource bindingSource = new BindingSource() {
                DataSource = categoryDTOs
            };
            form.GetDataGridViewCategory().DataSource = bindingSource;
            form.GetBindingNavigatorCategory().BindingSource = bindingSource;
            form.getIdCategory().DataBindings.Clear();
            form.getNameCategory().DataBindings.Clear();
            form.getIdCategory().DataBindings.Add("Text", bindingSource, "idCategory");
            form.getNameCategory().DataBindings.Add("Text", bindingSource, "name");
        }
    }
}
