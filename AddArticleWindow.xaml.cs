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
    public partial class AddArticleWindow : Window
    {
        public Article NewArticle { get; set; } = new();
        public List<Category> Category { get; set; }
        public SkiStoreContext Context { get; set; } = new();
        public AddArticleWindow()
        {
            GetCategory();
            InitializeComponent();
            DataContext = this;
        }

        private void SaveNewArticle(object sender, RoutedEventArgs e)
        {
            if (!Context.Articles.Any(x => x.Number == NewArticle.Number))
            {
                NewArticle.Available = false;
                NewArticle.Counter = 0;
                Context.Articles.Add(NewArticle);
                Context.SaveChanges();
                this.Close();
                
            }
            else
                MessageBox.Show("Article Number Already exists");
        }
        private void GetCategory()
        {
            Category = Context.Categories.ToList();
        }
    }
}
