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
using EntityFrameworkCoreExample.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EntityFrameworkCoreExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BookStoreService _bookStoreService;

        public MainWindow()
        {
            InitializeComponent();

            var context = new BookStoreContext();
            _bookStoreService = new BookStoreService(context);
            LoadData();

        }

        private async void LoadData()
        {
            var booksWithAuthors = await _bookStoreService.GetBooksWithAuthorsAsync();
            BooksDataGrid.ItemsSource = booksWithAuthors;
        }
    }
}