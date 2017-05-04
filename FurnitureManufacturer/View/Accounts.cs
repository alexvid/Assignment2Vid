using FurnitureManufacturer.BL;
using FurnitureManufacturer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FurnitureManufacturer
{
    public partial class Accounts : Form
    {
        internal User user;


        public Accounts(User user)
        {
            this.user = user;
            InitializeComponent();
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
                Product product = new Models.Product();
                product.Name = txtNameProduct.Text;
                product.Price = (float)Convert.ToDouble(txtPriceProduct.Text);
                product.Stock = Convert.ToInt32(txtStockProduct.Text);
                product.Description = txtDescriptionProduct.Text;

                UserOperations bl = new UserOperations();

                ID = bl.AddProduct(product);
                EmptyControlsProduct();
                MessageBox.Show("Operation succesful");
                //RaportFactory history = new RaportFactory();
                //Raport raport = history.createRaport("Product", this.user.ID, ID, DateTime.Now);
                History history = new History();
                history.IDEmployee = this.user.ID;
                history.IDOperation = ID;
                history.Date = DateTime.Now;
                history.TableName = "Product";

                bl.AddToHistory(history);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
                Product product = new Models.Product();
                product.ID = Convert.ToInt32(txtIdProduct.Text);
                product.Name = txtNameProduct.Text;
                product.Price = (float)Convert.ToDouble(txtPriceProduct.Text);
                product.Stock = Convert.ToInt32(txtStockProduct.Text);
                product.Description = txtDescriptionProduct.Text;

                UserOperations bl = new UserOperations();

                ID = bl.UpdateProduct(product);
                EmptyControlsProduct();
                MessageBox.Show("Operation succesful");
                //RaportFactory history = new RaportFactory();
                //Raport raport = history.createRaport("Product", this.user.ID, ID, DateTime.Now);

                History history = new History();
                history.IDEmployee = this.user.ID;
                history.IDOperation = ID;
                history.Date = DateTime.Now;
                history.TableName = "Product";

                bl.AddToHistory(history);

                //bl.AddToHistory(raport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
                Product product = new Models.Product();
                product.ID = Convert.ToInt32(txtIdProduct.Text);
                product.Name = txtNameProduct.Text;

                UserOperations bl = new UserOperations();

                ID = bl.DeleteProduct(product);
                EmptyControlsProduct();
                MessageBox.Show("Operation succesful");

                //RaportFactory history = new RaportFactory();
                //Raport raport = history.createRaport("Product", this.user.ID, ID, DateTime.Now);

                //bl.AddToHistory(raport);
                History history = new History();
                history.IDEmployee = this.user.ID;
                history.IDOperation = ID;
                history.Date = DateTime.Now;
                history.TableName = "Product";

                bl.AddToHistory(history);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewProduct_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = new Models.Product();
                string text = txtIdProduct.Text;
                if (text == "")
                    product.ID = 0;
                else
                    product.ID = Convert.ToInt32(text);
                UserOperations bl = new UserOperations();
                gridProduct.DataSource = bl.ListProduct(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void EmptyControlsProduct()
        {
            txtIdProduct.Text = string.Empty;
            txtNameProduct.Text = string.Empty;
            txtPriceProduct.Text = string.Empty;
            txtStockProduct.Text = string.Empty;
            txtDescriptionProduct.Text = string.Empty;
            gridProduct.SelectedRows[0].Selected = false;
        }



        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
                OrderProducts orderProduct = new OrderProducts();

                orderProduct.IDOrder = Convert.ToInt32(txtIDOrder2.Text);
                orderProduct.IDProduct = Convert.ToInt32(txtIDProduct2.Text);
                orderProduct.Quantity = Convert.ToInt32(txtQuantity.Text);

                UserOperations bl = new UserOperations();
                ID = bl.AddToOrder(orderProduct);
                //RaportFactory history = new RaportFactory();
                //Raport raport = history.createRaport("Order", this.user.ID, ID, DateTime.Now);

                //bl.AddToHistory(raport);
                History history = new History();
                history.IDEmployee = this.user.ID;
                history.IDOperation = ID;
                history.Date = DateTime.Now;
                history.TableName = "Order";

                bl.AddToHistory(history);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnDeleteFromOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
                OrderProducts orderProduct = new OrderProducts();

                orderProduct.IDOrder = Convert.ToInt32(txtIDOrder2.Text);
                orderProduct.IDProduct = Convert.ToInt32(txtIDProduct2.Text);

                UserOperations bl = new UserOperations();
                ID = bl.DeleteFromOrder(orderProduct);

                //RaportFactory history = new RaportFactory();
                //Raport raport = history.createRaport("Order", this.user.ID, ID, DateTime.Now);

                //bl.AddToHistory(raport);
                History history = new History();
                history.IDEmployee = this.user.ID;
                history.IDOperation = ID;
                history.Date = DateTime.Now;
                history.TableName = "Order";

                bl.AddToHistory(history);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
                Order order = new Order();
                order.Customer = txtCustomer.Text;
                order.Address = txtAddress.Text;
                order.DeliveryDate = dateDelivery.Value.Date;

                UserOperations bl = new UserOperations();
                ID = bl.AddOrder(order);


                //RaportFactory history = new RaportFactory();
                //Raport raport = history.createRaport("Order", this.user.ID, ID, DateTime.Now);

                //bl.AddToHistory(raport);
                History history = new History();
                history.IDEmployee = this.user.ID;
                history.IDOperation = ID;
                history.Date = DateTime.Now;
                history.TableName = "Order";

                bl.AddToHistory(history);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                int ID;
               
                Order order = new Order();

                order.ID = Convert.ToInt32(txtIDOrder.Text);
                order.Customer = txtCustomer.Text;
                order.Address = txtAddress.Text;
                order.DeliveryDate = dateDelivery.Value.Date;

                UserOperations bl = new UserOperations();
                ID = bl.UpdateOrder(order);
                //RaportFactory history = new RaportFactory();
                //Raport raport = history.createRaport("Order", this.user.ID,ID, DateTime.Now);

                //bl.AddToHistory(raport);

                History history = new History();
                history.IDEmployee = this.user.ID;
                history.IDOperation = ID;
                history.Date = DateTime.Now;
                history.TableName = "Order";

                bl.AddToHistory(history);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Order order = new Order();
                string text = txtIDOrder.Text;
                if (text == "")
                    order.ID = 0;
                else
                    order.ID = Convert.ToInt32(text);
                UserOperations bl = new UserOperations();
                gridOrder.DataSource = bl.ListOrder(order);
                gridProducts2.DataSource = bl.ListOrderProducts(order);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
