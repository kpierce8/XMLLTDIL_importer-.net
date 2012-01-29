using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Data.SqlServerCe;

namespace XMLImportLTDILWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            try
            {
                InitializeComponent();
              //  Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");

                XMLgetter goGet = new XMLgetter();
                goGet.InitializeXMLData();
                test.ItemsSource = goGet.observeableQuestions;

            //speciesNamesEntities db = new speciesNamesEntities();
            //var theQuestions = db.speciesTables.Where(p=>p.speciesID < 4);
            //ObservableCollection<speciesTable> outy = new ObservableCollection<speciesTable>();

           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                // Log error (including InnerExceptions!)
                // Handle exception
            }
        }

       

    }
}
