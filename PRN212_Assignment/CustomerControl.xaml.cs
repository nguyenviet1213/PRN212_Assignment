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
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {
        SalesManagementSystemContext context = new SalesManagementSystemContext();
        public CustomerControl()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            String keyword = txtSearch.Text;
            if (keyword.IsNullOrEmpty())
            {
                var customerList = context.Customers.ToList();
                customerGrid.ItemsSource = customerList;
            }
            else
            {
                var customerList = context.Customers.Where(c => c.Name.ToLower().Contains(keyword.ToLower())
                                                             || c.Address.ToLower().Contains(keyword.ToLower())
                                                             || c.Phone.ToLower().Contains(keyword.ToLower())
                                                             ).ToList();
                customerGrid.ItemsSource = customerList;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            CustomerFormWindow customerForm = new CustomerFormWindow();
            if (customerForm.ShowDialog() == true)
            {
                loadData();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (customerGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer to edit.");
                return;
            }
            CustomerFormWindow customerForm = new CustomerFormWindow((Customer)customerGrid.SelectedItem);
            if (customerForm.ShowDialog() == true)
            {
                loadData();
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = (Customer)customerGrid.SelectedItem;
            if (customer == null)
            {
                MessageBox.Show("Please select a customer to delete.");
                return;
            }
            if (MessageBox.Show($"Are you sure you want to delete customer {customer.Name}?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    context.Customers.Remove(customer);
                    context.SaveChanges();
                    loadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting customer: {ex.Message}");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadData();
        }
    }
}
