using Microsoft.EntityFrameworkCore;
using SkiStoreProject.DbModels;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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

namespace SkiStoreProject.Pages
{
    /// <summary>
    /// Interaction logic for LendArticlePage.xaml
    /// </summary>
    public partial class LendArticlePage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private List<Article> articles;
        public List<Article> Articles 
        {
            get => articles;
            set
            {
                articles = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(articles)));
            }
        }

        public List<Customer> Customers { get; set; }
        public SkiStoreContext Context { get; set; } = new();
        public Customer SelectedCustomer { get; set; } = new();
        public Article SelectedArticle { get; set; } = new();
        public LendArticlePage()
        {
            InitializeComponent();
            DataContext = this;
            LoadList();
        }


        public void LoadList()
        {
            try
            {
                Customers = Context.Customers.ToList();

                Articles = Context.Articles.Where(x => x.Available == false)
                    .Include(x => x.Category)
                    .OrderBy(x => x.Counter).ToList();
            }
            catch (Exception e)
            {
                MessageBox.Show("Db verbindung fehlgeschlagen");
            }
        }

        private void SaveRent(object sender, RoutedEventArgs e)
        {
            SelectedArticle.Available = true;
            SelectedArticle.CustomerId = SelectedCustomer.Id;

            try
            {
                Context.Update(SelectedArticle);
                Context.SaveChanges();
            }
            catch (Exception)
            {
                MessageBox.Show("Db verbindung fehlgeschlagen");
            }

            LoadList();
        }

    }
}
