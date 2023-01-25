using SkiStoreProject.DbModels;
using SkiStoreProject.Pages;
using SkiStoreProject.Windows;
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

namespace SkiStoreProject
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

        private void AddArticle(object sender, RoutedEventArgs e)
        {
            new AddArticleWindow().Show();
        }

        private void AddCustomer(object sender, RoutedEventArgs e)
        {
            new AddCustomerWindow().Show();
        }

        private void LendArticle(object sender, RoutedEventArgs e)
        {
            MWFrame.Content = new LendArticlePage();
        }

        private void ReturnArticle(object sender, RoutedEventArgs e)
        {
            MWFrame.Content = new ReturnArticlePage();
        }

        private void AddEmployeeAccount()
        {
            SkiStoreContext context = new SkiStoreContext();

            Employee newAccount = new Employee()
            {
                Username = "admin",
                Password = BCrypt.Net.BCrypt.HashPassword("asdf")
            };

            context.Employees.Add(newAccount);
            context.SaveChanges();
        }
    }
}
