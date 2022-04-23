using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfEinkaufsliste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Category> categories = new List<Category>();
        List<Product> products = new List<Product>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void addList_Click(object sender, RoutedEventArgs e)
        {
            //Dialog öffnen für Pfad
            string path;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            path = dialog.FileName;

            try
            {
                //  StreamRead öffnet die Datei als Stream und der using handhabt den Stream.
                using (var reader = new StreamReader(path))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');

                        this.products.Add(new Product(values[1], new Category(values[0])));
                    }
                }

                // Dieses Linq statement grupiert die Produkte nach Kategoriename und 
                // nimmt jeweils die Kategorie des ersten Produkts jeder Gruppe.
                this.categories = products.GroupBy(p => p.Category.Name).Select(x => x.First().Category).ToList();

                // Geht überalle kategorien und fügt sie der Combobox hinzu.
                foreach (var item in this.categories)
                {
                    this.ComboBox1.Items.Add(item.Name);
                }
            }
            catch (Exception)
            {
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var categoryName = (string)(sender as ComboBox).SelectedItem;

            foreach (var product in this.products)
            {
                if (product.Category.Name == categoryName)
                {
                    this.ComboBox2.Items.Add(product.Name);
                }
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = (string)this.ComboBox1.SelectedItem;
            var selectedProduct = (string)this.ComboBox2.SelectedItem;

            if (string.IsNullOrEmpty(selectedCategory) || string.IsNullOrEmpty(selectedProduct))
            {
                MessageBox.Show("Bitte wählen Sie im Dropdown eine Kategorie und ein Produkt aus.");
            }

            this.listBox.Items.Add(new Product(selectedProduct, new Category(selectedCategory)));
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addList_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void print_Click(object sender, RoutedEventArgs e)
        {

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
