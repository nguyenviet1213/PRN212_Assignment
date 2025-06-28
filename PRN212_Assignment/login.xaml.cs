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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Password;

            try
            {
                if (Login(username, password) == null)
                {
                    // Login successful, proceed to the main window
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close(); // Close the login window
                }
                else
                {
                    // Show error message
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        public Employee? Login(string username, string password)
        {
            using (var context = new SalesManagementSystemContext())
            {
                var employee = context.Employees
                    .FirstOrDefault(e => e.Username == username && e.Password == password);
                return employee;
            }
        }
    }
}
