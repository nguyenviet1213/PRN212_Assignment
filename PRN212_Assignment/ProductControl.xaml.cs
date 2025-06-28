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