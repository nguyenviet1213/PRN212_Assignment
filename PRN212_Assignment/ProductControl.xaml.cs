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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.IdentityModel.Tokens;
using PRN212_Assignment.Models;

namespace PRN212_Assignment
{
    /// <summary>
    /// Interaction logic for ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        SalesManagementSystemContext context = new SalesManagementSystemContext();
        public ProductControl()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            String keyword = txtSearch.Text;
            if (keyword.IsNullOrEmpty())
            {
                var productList = context.Products.ToList();
                productGrid.ItemsSource = productList;
            }
            else{
                var productList = context.Products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())
                                                           || p.Price.ToString().ToLower().Contains(keyword.ToLower())
                                                           || p.Category.ToLower().Contains(keyword.ToLower())
                                                            ).ToList();
                productGrid.ItemsSource = productList;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ProductFormWindow productForm = new ProductFormWindow();
            bool? result = productForm.ShowDialog();
            if (result == true)
            {
                loadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (productGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to edit.");
                return;
            }
            Product selectedProduct = (Product)productGrid.SelectedItem;
            ProductFormWindow productForm = new ProductFormWindow(selectedProduct);
            bool? result = productForm.ShowDialog();
            if (result == true)
            {
                loadData();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (productGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a product to delete.");
                return;
            }
            Product selectedProduct = (Product)productGrid.SelectedItem;
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the product: {selectedProduct.Name}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Products.Remove(selectedProduct);
                    context.SaveChanges();
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting product: {ex.Message}");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadData();
        }
    }

}