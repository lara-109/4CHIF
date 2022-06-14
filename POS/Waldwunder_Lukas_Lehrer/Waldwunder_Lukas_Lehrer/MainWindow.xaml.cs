using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Linq;
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

namespace Waldwunder_Lukas_Lehrer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Waldwunder> obsWaldwunder;
        DataContext db;
        public MainWindow()
        {
            InitializeComponent();

            String cs = "Data Source=Waldwunder.db";
            SqliteConnection connection = new SqliteConnection(cs);
            db = new DataContext(connection);
            Table<Waldwunder> table_waldwunder = db.GetTable<Waldwunder>();
            Table<Bilder> table_bilder = db.GetTable<Bilder>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window addDialog = new AddWaldwunder();
            addDialog.Show();



        }

        public void refresh()
        {
            Table<Waldwunder> table_waldwunder = db.GetTable<Waldwunder>();
            obsWaldwunder = new ObservableCollection<Waldwunder>(table_waldwunder.ToList());

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
