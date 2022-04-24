using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Serialization;

namespace XMLLernen
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Person> personenL;
        public MainWindow()
        {
            InitializeComponent();

            personenL = new ObservableCollection<Person>();
            Listbox.ItemsSource = personenL;
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            /*
            if(string.IsNullOrEmpty(Vorname.Text) || string.IsNullOrEmpty(Nachname.Text) || string.IsNullOrEmpty(Geb.Text))
            {
                e.CanExecute = false;
                return;
            }
            */
            e.CanExecute = true;
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            string vn = Vorname.Text;
            string nn = Nachname.Text;
            string gb = Geb.Text;

            personenL.Add(new Person(vn, nn, gb));
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            open.FilterIndex = 1;

            string filename = "";
            if(open.ShowDialog() == true)
            {
                filename = open.FileName;

                
            }
            XmlSerializer reader = new XmlSerializer(typeof(PersonenL));
            FileStream file = File.OpenRead(filename);
            PersonenL personenlistobj = (PersonenL)reader.Deserialize(file);
            file.Close();

            var newList = personenlistobj.personenL;
            personenL = newList;
            Listbox.ItemsSource = personenL;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            save.FilterIndex = 1;

            string path = "";
            if(save.ShowDialog() == true)
            {
                path = save.FileName;
            }

            XmlSerializer writer = new XmlSerializer(typeof(PersonenL));
            PersonenL personenlistobj = new PersonenL();
            FileStream file = File.Create(path);
            personenlistobj.personenL = personenL;
            writer.Serialize(file, personenlistobj);
            file.Close();
        }
    }
}
