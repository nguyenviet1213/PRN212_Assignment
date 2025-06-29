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
    /// <summary>
    /// Interaction logic for CustomerFormWindow.xaml
    /// </summary>
    public partial class CustomerFormWindow : Window
    {
        SalesManagementSystemContext context = new SalesManagementSystemContext();
        public Customer? EditCustomer { get; set; }
        public CustomerFormWindow(Customer customer)
        {
            InitializeComponent();
            this.DataContext = customer;
            EditCustomer = customer;
            Window.Title = "Edit Customer";
        }
        public CustomerFormWindow()
        {
            InitializeComponent();
            Window.Title = "Add Customer";
        }


        public void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Window.Title == "Add Customer")
            {
                addCustomer();
            }
            else
            {
                editCustomer();
            }
        }

        public void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editCustomer()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone cannot be empty.");
                return;
            }

            var customer = context.Customers.Find(EditCustomer.CustomerId);
            customer.Name = txtName.Text.Trim();
            customer.Phone = txtPhone.Text.Trim();
            customer.Address = txtAddress.Text.Trim();
            try
            {
                context.SaveChanges();
                MessageBox.Show("Customer updated successfully.");
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}");
                return;
            }
        }

        private void addCustomer()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Phone cannot be empty.");
                return;
            }
            Customer customer = new Customer
            {
                Name = txtName.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };
            try
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                MessageBox.Show("Customer added successfully.");
                this.DialogResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}");
                return;
            }
        }
    }
}
