using System;
using System.Collections.Generic;
using System.Globalization;
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
using Microsoft.EntityFrameworkCore;
using PRN212_Assignment.Models;

namespace PRN212_Assignment
{
    /// <summary>
    /// Interaction logic for InvoiceDetailWindow.xaml
    /// </summary>
    public partial class InvoiceDetailWindow : Window
    {
        SalesManagementSystemContext context = new SalesManagementSystemContext();

        //public Invoice ChoosedInvoice { get; set; }
        public InvoiceDetailWindow(Invoice invoice)
        {
            InitializeComponent();
            //ChoosedInvoice = invoice;
            LoadInvoiceInfo(invoice);
            LoadInvoiceDetails(invoice.InvoiceId);
        }

        private void LoadInvoiceInfo(Invoice invoice)
        {
            spInvoiceInfo.DataContext = invoice;
        }

        private void LoadInvoiceDetails(int invoiceId)
        {
            var invoiceDetails = context.InvoiceDetails.Include(id => id.Product)
                .Where(id => id.InvoiceId == invoiceId)
                .ToList();
            dgDetails.ItemsSource = invoiceDetails;
            txtTotalAmount.Text = invoiceDetails.Sum(id => id.Price).ToString("C2"); // Assuming Quantity and Price are properties of InvoiceDetail
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            // Logic to add a new invoice detail
            // This could open another window or prompt for input
        }

        private void RemoveRow_Click(object sender, RoutedEventArgs e)
        {
            // Logic to add a new invoice detail
            // This could open another window or prompt for input
        }

        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            // Logic to add a new invoice detail
            // This could open another window or prompt for input
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
