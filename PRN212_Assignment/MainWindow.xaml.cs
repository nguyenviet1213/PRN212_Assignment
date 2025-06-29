using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN212_Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Product_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProductControl();
        }

        private void Customer_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CustomerControl();
        }

        private void Invoice_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InvoiceControl();
        }
        private void MakeInvoice_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoiceWindow createInvoiceWindow = new CreateInvoiceWindow();
            createInvoiceWindow.Show();
        }

        public void Logout_Click(object sender, RoutedEventArgs e)
        {
            login loginWindow = new login();
            loginWindow.Show();
            this.Close();
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}