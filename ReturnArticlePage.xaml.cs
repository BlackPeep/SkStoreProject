using Microsoft.EntityFrameworkCore;
using SkiStoreProject.DbModels;
using System;
using System.Collections.Generic;
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
    public partial class ReturnArticlePage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private List<Article> articles = new();
        public List<Article> Articles
        { 
            get => articles;

            set
            {
                articles = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(articles)));
            }
        }
        public SkiStoreContext Context { get; set; } = new();
        public Article SelectedArticle { get; set; } = new();
        public ReturnArticlePage()
        {
            InitializeComponent();
            DataContext = this;
            LoadList();
        }


        public void LoadList()
        {
            try
            {
                Articles = Context.Articles
                       .Include(x => x.Customer)
                       .Where(x => x.Available == true).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("Db verbindung fehlgeschlagen");
            }
        }

        private void SaveReturn(object sender, RoutedEventArgs e)
        {
            SelectedArticle.Available = false;
            SelectedArticle.Counter++;
            SelectedArticle.Customer = null;

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
