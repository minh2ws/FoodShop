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
            categoryDetail.setStateUpdate(false);
        }

        public void editCategory()
        {
            frmCategoryDetail categoryDetail = new frmCategoryDetail(true, this);
            categoryDetail.setStateUpdate(true);
            categoryDetail.getCategoryName().Text = form.getNameCategory().Text;
            DialogResult r = categoryDetail.ShowDialog();
        }
        public void addProduct()
        {
            frmProductDetail ProductDetail = new frmProductDetail(true,this);
            ProductDetail.setUpdateState(false);
            ProductDetail.getComboBoxCategory().DataSource = bindingSourceCategory;
            ProductDetail.getComboBoxCategory().DisplayMember = "name";
            ProductDetail.getComboBoxCategory().ValueMember = "idCategory";
            DialogResult r = ProductDetail.ShowDialog();
        }
        public void editProduct()
        {
            frmProductDetail ProductDetail = new frmProductDetail(true,this);
            ProductDetail.setUpdateState(true);
            ProductDetail.getPrice().Text = form.getPriceProduct().Text;
            ProductDetail.getProductName().Text = form.getNameProduct().Text;
            ProductDetail.getQuantity().Text = form.getQuantityProduct().Text;
            ProductDetail.getComboBoxCategory().DataSource = bindingSourceCategory;
            ProductDetail.getComboBoxCategory().DisplayMember = "name";
            ProductDetail.getComboBoxCategory().ValueMember = "idCategory";
            DataTable dataTableCategory = (DataTable)bindingSourceCategory.DataSource;
            var selectedIdCategory = "";
            foreach(DataRow row in dataTableCategory.Rows)
            {
                if (row["name"].ToString().Equals(form.getCategoryProduct().Text))
                {
                    selectedIdCategory = row["idCategory"].ToString();
                }
            }
            ProductDetail.getComboBoxCategory().SelectedValue = selectedIdCategory;

            DialogResult r = ProductDetail.ShowDialog();
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
                form.GetDataGridViewCategory().Columns["idCategory"].Visible = false;
                form.GetBindingNavigatorCategory().BindingSource = bindingSourceCategory;
                clearDataBindingTextCategory();
                bindingDataTextCategory();
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR+" Get All Category");
            }
           
        }
        private void bindingDataTextCategory()
        {
            form.getIdCategory().DataBindings.Add("Text", bindingSourceCategory, "idCategory");
            form.getNameCategory().DataBindings.Add("Text", bindingSourceCategory, "name");
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
            form.getCategoryProduct().DataBindings.Clear();
            form.getStatusProduct().DataBindings.Clear();
        }
        private void bindingDataTextProduct()
        {
            form.getIdProduct().DataBindings.Add("Text", bindingSourceProduct, "idProduct");
            form.getNameProduct().DataBindings.Add("Text", bindingSourceProduct, "name");
            form.getPriceProduct().DataBindings.Add("Text", bindingSourceProduct, "price");
            form.getQuantityProduct().DataBindings.Add("Text", bindingSourceProduct, "quantity");
            form.getCategoryProduct().DataBindings.Add("Text", bindingSourceProduct, "categoryName");
            form.getStatusProduct().DataBindings.Add("Text", bindingSourceProduct, "status");
        }
        public void saveCategory(frmCategoryDetail frmCategory)
        {
            try
            {
                TblCategoryDTO categoryDTO = new TblCategoryDTO();
                categoryDTO.name = frmCategory.getCategoryName().Text;
                categoryDTO.idCategory = form.getIdCategory().Text;
                if (!frmCategory.getStateUpdate())
                {
                    categoryModel.addCategory(categoryDTO);
                    getAllCategory();
                    getAllProduct();
                }
                else
                {
                    categoryModel.updateCategory(categoryDTO);
                    getAllCategory();
                    getAllProduct();
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
                bindingSourceCategory.Filter = "name LIKE '%" + searchValue + "%'";
                
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR+" Search Category");
            }
            
        }
        public void searchProductName()
        {
            try
            {
                string searchValue = form.getSearchProductName().Text;
                if (searchValue.Equals(""))
                {
                    bindingSourceProduct.Filter = "";
                }
                else
                {
                    bindingSourceProduct.Filter = "name LIKE '%" + searchValue + "%' and idCategory = " + form.GetComboBoxTable().SelectedValue;
                }
               
            }
            catch(Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR+" Search Category"+e.Message);
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
                form.GetDataGridViewProduct().Columns["idProduct"].Visible = false;
                form.GetDataGridViewProduct().Columns["idCategory"].Visible = false;
                form.GetComboBoxTable().DataSource = bindingSourceCategory;
                form.GetComboBoxTable().DisplayMember="name";
                form.GetComboBoxTable().ValueMember = "idCategory";
                clearDataBindingTextProduct();
                bindingDataTextProduct();
            }
            catch (Exception e)
            {
                MessageBox.Show(MessageUtil.ERROR + " Get All Product"+e.Message);
            }
        }

        public void saveProduct(frmProductDetail frmProductDetail)
        {
            TblProductsDTO tblProductsDTO = new TblProductsDTO();
            tblProductsDTO.price = float.Parse(frmProductDetail.getPrice().Text);
            tblProductsDTO.name = frmProductDetail.getProductName().Text;
            tblProductsDTO.quantity = int.Parse(frmProductDetail.getQuantity().Text);
            tblProductsDTO.idCategory = frmProductDetail.getComboBoxCategory().SelectedValue.ToString();
            tblProductsDTO.status = bool.Parse(form.getStatusProduct().Text);
            if (!frmProductDetail.getUpdateState())
            {
                if (productModel.addProduct(tblProductsDTO))
                {
                    MessageBox.Show(MessageUtil.SAVE_SUCCESS);
                    getAllProduct();
                }
                else
                {
                    MessageBox.Show(MessageUtil.ERROR + " save Product");
                }
            }
            else
            {
                tblProductsDTO.idProduct = form.getIdProduct().Text;
                if (productModel.updateProduct(tblProductsDTO))
                {
                    MessageBox.Show(MessageUtil.SAVE_SUCCESS);
                    getAllProduct();
                }
                else
                {
                    MessageBox.Show(MessageUtil.ERROR + " save Product");
                }
            }
        }

        public void deleteCategory()
        {
            throw new NotImplementedException();
        }

        public void deleteProduct()
        {
            if (bool.Parse(form.getStatusProduct().Text))
            {
                DialogResult dr = MessageBox.Show(MessageUtil.DELETE_CONFIRM, "warning", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        TblProductsDTO productsDTO = new TblProductsDTO();
                        productsDTO.idProduct = form.getIdProduct().Text;
                        productsDTO.status = false;

                        if (productModel.setStatusProduct(productsDTO))
                        {
                            MessageBox.Show(MessageUtil.DELETE_SUCCESS);
                        }
                        getAllProduct();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(MessageUtil.ERROR);
                    }
                }
            }
            else
            {
                MessageBox.Show(MessageUtil.DELETE_ALREADY);
            }
            
        }
    }
}
