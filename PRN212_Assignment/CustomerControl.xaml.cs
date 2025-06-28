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

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            loadData();
        }
    }
}
