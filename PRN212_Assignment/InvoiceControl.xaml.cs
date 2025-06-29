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
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PRN212_Assignment.Models;

namespace PRN212_Assignment
{
    public partial class InvoiceControl : UserControl
    {
        SalesManagementSystemContext context = new SalesManagementSystemContext();

        public InvoiceControl()
        {
            InitializeComponent();
            loadData();
        }

        public void loadData()
        {
            String keyword = txtSearch.Text;
            if (keyword.IsNullOrEmpty())
            {
                var invoiceList = context.Invoices.Include(i => i.Employee).Include(i => i.Customer).ToList();
                invoiceGrid.ItemsSource = invoiceList;
            }
            else
            {
                var invoiceList = context.Invoices
                        .Include(i => i.Customer)
                        .Include(i => i.Employee)
                        .Where(i => i.Customer != null && i.Customer.Name.ToLower().Contains(keyword)
                                 || i.Employee.Name.ToLower().Contains(keyword)
                                 || i.TotalAmount.ToString().Contains(keyword)
                                 || i.Date.ToString().Contains(keyword))
                        .ToList();
                invoiceGrid.ItemsSource = invoiceList;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ViewDetail_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                Button? btn = sender as Button;
                var invoiceId = (int)btn.Tag;
                Invoice? i = context.Invoices.Include(i => i.Employee)
                                             .Include(c => c.Customer)
                                             .FirstOrDefault(inv => inv.InvoiceId == invoiceId);
                InvoiceDetailWindow detailWindow = new InvoiceDetailWindow(i);
                detailWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the invoice details: " + ex.Message);
            }
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadData();
        }
    }
}
