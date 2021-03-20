using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using FoodShopManagement_WF.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter.impl
{
    public class CategoryPresenter : ICategoryPresenter
    {
        private ICategoryModel categoryModel = new CategoryModel();
        private frmWarehouse_V2 form;
        private BindingSource bindingSource;
        public CategoryPresenter()
        {

        }
        public CategoryPresenter (frmWarehouse_V2 form)
        {
            this.form = form;
        }

        public void add()
        {
            frmCategoryDetail categoryDetail = new frmCategoryDetail(true,this);
            DialogResult r = categoryDetail.ShowDialog();
            categoryDetail.getCategoryId().Enabled = true;
        }

        public void edit()
        {
            frmCategoryDetail categoryDetail = new frmCategoryDetail(true, this);
            categoryDetail.getCategoryId().Enabled = false;
            categoryDetail.getCategoryId().Text = form.getIdCategory().Text;
            categoryDetail.getCategoryName().Text = form.getNameCategory().Text;
            DialogResult r = categoryDetail.ShowDialog();
        }

        public void getAll()
        {
            try
            {
                List<TblCategoryDTO> categoryDTOs = categoryModel.getAll();
                DataTable dataTable = ConvertCustom.ListToDataTable(categoryDTOs);
                bindingSource = new BindingSource()
                {
                    DataSource = dataTable
                };
                form.GetDataGridViewCategory().DataSource = bindingSource;
                form.GetBindingNavigatorCategory().BindingSource = bindingSource;
                clearDataBindingText();
                form.getIdCategory().DataBindings.Add("Text", bindingSource, "idCategory");
                form.getNameCategory().DataBindings.Add("Text", bindingSource, "name");
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR+" Get All");
            }
           
        }
        private void clearDataBindingText()
        {
            form.getNameCategory().DataBindings.Clear();
            form.getIdCategory().DataBindings.Clear();
        }

        public void save(frmCategoryDetail form)
        {
            TblCategoryDTO categoryDTO = new TblCategoryDTO();
            categoryDTO.name = form.getCategoryName().Text;
            categoryDTO.idCategory = form.getCategoryId().Text;
            if (form.getCategoryId().Enabled)
            {
                categoryModel.addCategory(categoryDTO);
                getAll();
            }
            else
            {
                categoryModel.updateCategory(categoryDTO);
                getAll();
            }
            MessageBox.Show(MessageUtil.SAVE_SUCCESS);
        }

        public void search()
        {
            try
            {
                string searchValue = form.getSearchCategoryBox().Text;
                bindingSource.Filter="name LIKE '%" + searchValue + "%'";
                
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR+" Search");
            }
            
        }
    }
}
