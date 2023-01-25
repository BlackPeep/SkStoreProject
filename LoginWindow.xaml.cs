using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using SkiStoreProject.DbModels;
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

namespace SkiStoreProject.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public Employee Employee { get; set; } = new();
        public SkiStoreContext Context { get; set; } = new();
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CheckLogin(object sender, RoutedEventArgs e)
        {
            var checkedEmployee = Context.Employees.FirstOrDefault(x => x.Username == Employee.Username);

            if (Employee.Username.IsNullOrEmpty() || PasswordBox.Password.IsNullOrEmpty())
                MessageBox.Show("Enter Username and Password");

            else if (checkedEmployee != null)
            {
                if (BCrypt.Net.BCrypt.Verify(PasswordBox.Password, checkedEmployee.Password))
                {
                    new MainWindow().Show();
                    this.Close();
                }
            }
            else
                MessageBox.Show("Wrong Username or Password");
            
        }
    }
}
