using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
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

namespace Datnbank_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    [Table(Name = "Book")]
    public class Book
        {
            [Column(IsPrimaryKey = true)] public int? ID { get; set; }
            [Column] public string Titel { get; set; }
            [Column] public int Year { get; set; }
        }


    public partial class MainWindow : Window
    {

        private void apply_Click(object sender, RoutedEventArgs e)
        {
            string titel = Titel.Text;
            int jahr = Int32.Parse((string)Year.Text);
            SqliteConnection sql = new SqliteConnection("Data Source=try.db");
            DataContext db = new DataContext(sql);
            Table<Book> books = db.GetTable<Book>();
            listbox.ItemsSource = books;
            

            // submitted erst bei einem "commit" = submit
            books.InsertOnSubmit(new Book() { Titel = titel, Year = jahr });
            // commiten = submitten
            db.SubmitChanges();
            
        }

        public MainWindow()
        {
            InitializeComponent();
            

        }

    }
}
