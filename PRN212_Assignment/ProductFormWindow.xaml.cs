using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PRN212_Assignment.Models;

namespace PRN212_Assignment
{
    public partial class ProductFormWindow : Window
    {
        SalesManagementSystemContext context = new SalesManagementSystemContext();

        public Product? EditProduct { get; set; }
        public ProductFormWindow(Product product)
        {
            InitializeComponent();
            this.DataContext = product;
            EditProduct = product;
            Window.Title = "Edit Product";
        }

        public ProductFormWindow()
        {
            InitializeComponent();
            Window.Title = "Add Product";

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Window.Title == "Add Product")
            {
                addProduct();
            }
            else
            {
                editProduct();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editProduct()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Please fill in the product name.");
                    return;
                }
                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCategory.Text))
                {
                    MessageBox.Show("Please fill in the product category.");
                    return;
                }
                if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
                {
                    MessageBox.Show("Please enter a valid stock quantity.");
                    return;
                }

                var product = context.Products.Find(EditProduct.ProductId);
                product.Name = txtName.Text.Trim();
                product.Price = decimal.Parse(txtPrice.Text.Trim());
                product.Category = txtCategory.Text.Trim();
                product.Stock = int.Parse(txtStock.Text.Trim());
                context.SaveChanges();
                MessageBox.Show("Product updated successfully!");
                this.DialogResult = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return;
            }
        }

        private void addProduct()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtCategory.Text))
                {
                    MessageBox.Show("Please fill in all fields.");
                    return;
                }
                
                if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid price.");
                    return;
                }
                Product product = new Product();
                product.Name = txtName.Text.Trim();
                product.Price = decimal.Parse(txtPrice.Text.Trim());
                product.Category = txtCategory.Text.Trim();
                product.Stock = int.Parse(txtStock.Text.Trim());
                context.Products.Add(product);
                context.SaveChanges();
                MessageBox.Show("Product added successfully!");
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return;
            }
        }
    }


}
