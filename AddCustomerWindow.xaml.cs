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
    /// Interaction logic for AddArticleWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public Customer NewCustomer { get; set; } = new();
        public SkiStoreContext Context { get; set; } = new();
        public AddCustomerWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveNewCustomer(object sender, RoutedEventArgs e)
        {
            Context.Customers.Add(NewCustomer);
            Context.SaveChanges();
            this.Close();
        }
    }
}
