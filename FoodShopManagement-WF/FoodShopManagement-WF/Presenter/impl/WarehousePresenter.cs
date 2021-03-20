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
    public class WarehousePresenter : IWarehousePresenter
    {
        private ICategoryModel categoryModel = new CategoryModel();
        private IProductModel productModel = new ProductModel();
        private frmWarehouse_V2 form;
        private BindingSource bindingSourceCategory;
        private BindingSource bindingSourceProduct;
        public WarehousePresenter()
        {

        }
        public WarehousePresenter (frmWarehouse_V2 form)
        {
            this.form = form;
        }

        public void addCategory()
        {
            frmCategoryDetail categoryDetail = new frmCategoryDetail(true,this);
            DialogResult r = categoryDetail.ShowDialog();
            categoryDetail.getCategoryId().Enabled = true;
        }

        public void editCategory()
        {
            frmCategoryDetail categoryDetail = new frmCategoryDetail(true, this);
            categoryDetail.getCategoryId().Enabled = false;
            categoryDetail.getCategoryId().Text = form.getIdCategory().Text;
            categoryDetail.getCategoryName().Text = form.getNameCategory().Text;
            DialogResult r = categoryDetail.ShowDialog();
        }

        public void getAllCategory()
        {
            try
            {
                List<TblCategoryDTO> categoryDTOs = categoryModel.getAll();
                DataTable dataTable = ConvertCustom.ListToDataTable(categoryDTOs);
                bindingSourceCategory = new BindingSource()
                {
                    DataSource = dataTable
                };
                form.GetDataGridViewCategory().DataSource = bindingSourceCategory;
                form.GetBindingNavigatorCategory().BindingSource = bindingSourceCategory;
                clearDataBindingTextCategory();
                form.getIdCategory().DataBindings.Add("Text", bindingSourceCategory, "idCategory");
                form.getNameCategory().DataBindings.Add("Text", bindingSourceCategory, "name");
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR+" Get All Category");
            }
           
        }
        private void clearDataBindingTextCategory()
        {
            form.getNameCategory().DataBindings.Clear();
            form.getIdCategory().DataBindings.Clear();
        }
        private void clearDataBindingTextProduct()
        {
            form.getIdProduct().DataBindings.Clear();
            form.getNameProduct().DataBindings.Clear();
            form.getPriceProduct().DataBindings.Clear();
            form.getQuantityProduct().DataBindings.Clear();
        }

        public void saveCategory(frmCategoryDetail form)
        {
            try
            {
                TblCategoryDTO categoryDTO = new TblCategoryDTO();
                categoryDTO.name = form.getCategoryName().Text;
                categoryDTO.idCategory = form.getCategoryId().Text;
                if (form.getCategoryId().Enabled)
                {
                    categoryModel.addCategory(categoryDTO);
                    getAllCategory();
                }
                else
                {
                    categoryModel.updateCategory(categoryDTO);
                    getAllCategory();
                }
                MessageBox.Show(MessageUtil.SAVE_SUCCESS);
            }catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Save Category");
            }
            
        }

        public void searchCategory()
        {
            try
            {
                string searchValue = form.getSearchCategoryBox().Text;
                bindingSourceCategory.Filter="name LIKE '%" + searchValue + "%'";
                
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR+" Search Category");
            }
            
        }
        public void getAllProduct()
        {
            try
            {
                List<TblProductsDTO> listProducts= productModel.getAll();
                DataTable dataTable = ConvertCustom.ListToDataTable(listProducts);
                bindingSourceProduct = new BindingSource()
                {
                    DataSource = dataTable
                };
                form.GetBindingNavigatorProduct().BindingSource = bindingSourceProduct;
                form.GetDataGridViewProduct().DataSource = bindingSourceProduct;
                clearDataBindingTextProduct();
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Get All Product");
            }
        }
    }
}
