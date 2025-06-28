﻿using System;
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
            var CustomerList = context.Customers.ToList();
            customerGrid.ItemsSource = CustomerList;
        }
    }
}
