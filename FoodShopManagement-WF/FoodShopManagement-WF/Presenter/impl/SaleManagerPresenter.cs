﻿using DTO;
using FoodShopManagement_WF.Model;
using FoodShopManagement_WF.Model.impl;
using FoodShopManagement_WF.UI;
using FoodShopManagement_WF.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodShopManagement_WF.Presenter.impl
{
    class SaleManagerPresenter : ISaleManagerPresenter
    {
        private IProductModel productModel = new ProductModel();
        private ICategoryModel categoryModel = new CategoryModel();
        private ICustomerModel customerModel = new CustomerModel();
        private IOrderModel orderModel = new OrderModel();
        private frmSaleManager_V2 form;
        private BindingSource bsProduct;
        private BindingSource bsCustomer;
        private List<TblProductsDTO> listProducts;
        private List<CartItemDTO> listProductOrder;

        public SaleManagerPresenter() { }

        public SaleManagerPresenter(frmSaleManager_V2 form)
        {
            this.form = form;
        }

        public void SearchProduct()
        {
            string categoryName = form.getCmbCategory().Text;
            string productName = form.getProductName().Text;
            listProducts = productModel.searchProduct(categoryName, productName);

            bsProduct.DataSource = listProducts;

            //binding data
            form.getDgvProduct().DataSource = bsProduct;
            form.getBnProduct().BindingSource = bsProduct;
        }

        public void AddCustomer()
        {
            frmCustomerDetail customerDetail = new frmCustomerDetail(true, form);
            DialogResult r = customerDetail.ShowDialog();
        }

        public void UpdateCustomer()
        {
            frmCustomerDetail customerDetail = new frmCustomerDetail(false, form);

            //get customer detail from frmSaleManager
            customerDetail.setCustomerId(form.getCustomerId().Text);
            customerDetail.getCustomerName().Text = form.getCustomerName().Text;
            customerDetail.getCustomerPhone().Text = form.getCustomerPhone().Text;
            customerDetail.getAddress().Text = form.getCustomerAddress().Text;

            //show customerDetail form
            DialogResult r = customerDetail.ShowDialog();
        }

        private bool checkCustomerField(string cusName, string cusPhone, string cusAddress)
        {
            if (cusName.Trim().Length <= 0 || cusName.Trim().Length > 50)
            {
                MessageBox.Show(MessageUtil.INVALID_CUS_NAME);
                return false;
            }

            try
            {
                int phoneNumber = int.Parse(cusPhone);
            }
            catch (FormatException)
            {
                MessageBox.Show(MessageUtil.INVALID_CUS_PHONE);
                return false;
            }

            if (cusAddress.Trim().Length <= 0 || cusAddress.Trim().Length > 200)
            {
                MessageBox.Show(MessageUtil.INVALID_CUS_ADDRESS);
                return false;
            }
            return true;
        }

        public void SaveCustomer(frmCustomerDetail frmCustomerDetail)
        {
            try
            {
                string name = frmCustomerDetail.getCustomerName().Text;
                string phone = frmCustomerDetail.getCustomerPhone().Text;
                string address = frmCustomerDetail.getAddress().Text;
                bool isValid = checkCustomerField(name, phone, address);
                if (isValid)
                {
                    TblCustomerDTO dto = new TblCustomerDTO()
                    {
                        idCustomer = frmCustomerDetail.getCustomerID(),
                        name = name,
                        phone = phone,
                        address = address
                    };
                    if (frmCustomerDetail.isAddNew())
                    {
                        customerModel.addCustomer(dto);
                        LoadCustomers();
                    }
                    else
                    {
                        customerModel.updateCustomer(dto);
                        LoadCustomers();
                    }
                    MessageBox.Show(MessageUtil.SAVE_SUCCESS);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(MessageUtil.ERROR + " Save Customer!");
            }
        }

        public void LoadProducts()
        {
            listProducts = productModel.getProductsToSale();
            DataTable dtProduct = ConvertCustom.ListToDataTable<TblProductsDTO>(listProducts);
            bsProduct = new BindingSource()
            {
                DataSource = dtProduct
            };

            //binding data to data grid view
            form.getBnProduct().BindingSource = bsProduct;
            form.getDgvProduct().DataSource = bsProduct;

            //hide unessesary column
            form.getDgvProduct().Columns["idProduct"].Visible = false;
            form.getDgvProduct().Columns["status"].Visible = false;
            form.getDgvProduct().Columns["idCategory"].Visible = false;
            form.getDgvProduct().Columns["categoryName"].Visible = false;

            List<TblCategoryDTO> listCategory = categoryModel.getAll();
            foreach (var category in listCategory)
            {
                form.getCmbCategory().Items.Add(category.name);
            }

            foreach (DataGridViewColumn column in form.getDgvProduct().Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void LoadCustomers()
        {
            List<TblCustomerDTO> listCustomers = customerModel.getCustomers();
            DataTable dtCustomer = ConvertCustom.ListToDataTable<TblCustomerDTO>(listCustomers);
            bsCustomer = new BindingSource()
            {
                DataSource = dtCustomer
            };

            //binding data to data grid view
            form.getBnCustomer().BindingSource = bsCustomer;
            form.getDgvCustomer().DataSource = bsCustomer;

            //hide unnecessary column
            form.getDgvCustomer().Columns["phone"].Visible = false;
            form.getDgvCustomer().Columns["address"].Visible = false;
            form.getDgvCustomer().Columns["point"].Visible = false;

            //clear and add new data binding
            clearDataBindingTextCustomer();
            bindingDataTextCustomer();
        }

        public void clearDataBindingTextCustomer()
        {
            form.getCustomerId().DataBindings.Clear();
            form.getCustomerName().DataBindings.Clear();
            form.getCustomerPhone().DataBindings.Clear();
            form.getCustomerAddress().DataBindings.Clear();
            form.getCustomerPoint().DataBindings.Clear();
        }

        public void bindingDataTextCustomer()
        {
            form.getCustomerId().DataBindings.Add("Text", bsCustomer, "idCustomer");
            form.getCustomerName().DataBindings.Add("Text", bsCustomer, "name");
            form.getCustomerPhone().DataBindings.Add("Text", bsCustomer, "phone");
            form.getCustomerAddress().DataBindings.Add("Text", bsCustomer, "address");
            form.getCustomerPoint().DataBindings.Add("Text", bsCustomer, "point");
        }

        public void SearchCustomer()
        {
            string searchValue = form.getSearchCustomer().Text;
            if (searchValue.Equals(""))
            {
                bsCustomer.Filter = "";
            }
            else
            {
                bsCustomer.Filter = "name like '%" + searchValue + "%'";
            }
        }

        public void AddProductToOrder()
        {
            DataGridView dgvProducts = form.getDgvProduct();
            //Get number of selected grow
            Int32 selectedRowCount = dgvProducts.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    //get selected row
                    String row = dgvProducts.SelectedRows[i].Index.ToString();
                    int rowInt = int.Parse(row);

                    //get product from list product
                    TblProductsDTO product = listProducts[rowInt];

                                        //new list product order
                    if (listProductOrder == null)
                        listProductOrder = new List<CartItemDTO>();

                    CartItemDTO item = findProductInOrder(product.idProduct);

                    if (item != null)
                    {
                        //increase quantity
                        item.quantity++;
                        //update totalPrice
                        item.totalPrice = item.quantity * item.price;
                    } else
                    {
                        item = new CartItemDTO()
                        {
                            idProduct = product.idProduct,
                            name = product.name,
                            price = product.price,
                            quantity = 1,
                            totalPrice = product.price * 1
                        };
                        //add product to list product order
                        listProductOrder.Add(item);
                    }
                }
            } else
            {
                MessageBox.Show("Select product you want to add", "Notification");
            }
        }

        public void LoadProductsOrder()
        {
            if (listProductOrder == null)
            {
                form.getDgvItemOfOrder().DataSource = null;
                form.getDgvItemOfOrder().Rows.Clear();
                return;
            }

            DataTable dtProduct = ConvertCustom.ListToDataTable<CartItemDTO>(listProductOrder);
            bsProduct = new BindingSource()
            {
                DataSource = dtProduct
            };

            //binding data to data grid view
            form.getDgvItemOfOrder().DataSource = bsProduct;

            form.getDgvItemOfOrder().Columns["idProduct"].Visible = false;

            foreach (DataGridViewColumn column in form.getDgvItemOfOrder().Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private float calculateTotalPrice()
        {
            if (listProductOrder == null)
                return 0;

            float totalPrice = 0;
            for (int i = 0; i < listProductOrder.Count; i++)
            {
                totalPrice += listProductOrder[i].totalPrice;
            }
            return totalPrice;
        }

        public CartItemDTO findProductInOrder(string idProduct)
        {
            for (int i = 0; i < listProductOrder.Count; i++)
            {
                if (listProductOrder[i].idProduct.Equals(idProduct))
                {
                    return listProductOrder[i];
                }
            }
            return null;
        }

        public void UpdateAmount()
        {
            form.getAmount().Text = calculateTotalPrice().ToString();
        }

        public void RemoveProductFromOrder()
        {
            
            if (MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DataGridView dgvItemOfOrder = form.getDgvItemOfOrder();
                //Get number of selected grow
                Int32 selectedRowCount = dgvItemOfOrder.Rows.GetRowCount(DataGridViewElementStates.Selected);
                if (selectedRowCount > 0)
                {
                    for (int i = 0; i < selectedRowCount; i++)
                    {
                        //get selected row
                        String row = dgvItemOfOrder.SelectedRows[i].Index.ToString();
                        int rowInt = int.Parse(row);

                        //get product from list product
                        CartItemDTO item = listProductOrder[rowInt];
                        listProductOrder.Remove(item);

                        //remove list
                        if (listProductOrder.Count == 0)
                            listProductOrder = null;
                    }
                }
                else
                {
                    MessageBox.Show("Select product you want to remove", "Notification");
                }
            }
            
        }

        public void CheckoutCart()
        {
            string customerOrder = form.getCustomerOrder().Text;
            if (customerOrder.Equals(""))
            {
                MessageBox.Show(MessageUtil.CUSTOMER_INVALID);
            }
            else CreateOrder();
        }

        private void CreateOrder()
        {
            //create order id
            string idOrder = new Random().Next(999999).ToString();
            TblOrderDTO order = new TblOrderDTO()
            {

                idOrder = idOrder,
                idEmployee = form.getEmployee().idEmployee,
                idCustomer = form.getCustomerId().Text,
                priceSum = float.Parse(form.getAmount().Text),
                discount = float.Parse(form.getDiscount().Text),
                total = float.Parse(form.getCurrentAmount().Text),
                orderDate = DateTime.Now,
            };
            
            bool isSuccess = orderModel.AddOrder(order);
            if (isSuccess)
            {
                //create order detail dto for insert to database
                List<TblOrderDetailDTO> itemList = new List<TblOrderDetailDTO>();
                foreach (var item in listProductOrder)
                {
                    TblOrderDetailDTO dto = new TblOrderDetailDTO()
                    {
                        idOrder = idOrder,
                        idProduct = item.idProduct,
                        quantity = item.quantity,
                        price = item.price,
                    };
                    itemList.Add(dto);
                }

                CartDTO cart = new CartDTO(idOrder, itemList);
                isSuccess = orderModel.AddOrderDetail(cart);
                if (isSuccess)
                {
                    MessageBox.Show(MessageUtil.CHECKOUT_SUCCESS);
                    updateCustomerPoint();
                }
                else 
                    MessageBox.Show(MessageUtil.ERROR);
            }
            else
            {
                MessageBox.Show(MessageUtil.ERROR);
            }
        }

        private void updateCustomerPoint()
        {
            //calculate point for customer
            int amount = int.Parse(form.getAmount().Text);
            int point = amount / 100;
            string customerId = form.getCustomerId().Text;

            TblCustomerDTO dto = new TblCustomerDTO()
            {
                idCustomer = customerId,
                point = point,
            };
            customerModel.updatePoint(dto);
        }

        public void GetCustomerInfo()
        {
            string customerId = form.getCustomerId().Text;
            if (customerId.Equals(""))
                MessageBox.Show(MessageUtil.CUSTOMER_EMPTY);
            else
                form.getCustomerOrder().Text = form.getCustomerName().Text;
        }

        public void UpdateQuantity(string idProduct, int quantity)
        {
            CartItemDTO item = findProductInOrder(idProduct);
            if (item != null)
                item.quantity = quantity;
        }

        public CartItemDTO FindProductToOrder()
        {
            DataGridView dgvItemOfOrder = form.getDgvItemOfOrder();
            //Get number of selected grow
            Int32 selectedRowCount = dgvItemOfOrder.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    //get selected row
                    String row = dgvItemOfOrder.SelectedRows[i].Index.ToString();
                    int rowInt = int.Parse(row);

                    //get product from list product
                    CartItemDTO item = listProductOrder[rowInt];

                    return item;
                }
            }
            else
            {
                MessageBox.Show("Select product you want to add", "Notification");
            }
            return null;
        }
    }
}
