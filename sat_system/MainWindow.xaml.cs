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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sat_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private Program Main;
        public readonly string[] typeOfSatellite =  { "Communication", "Photography","Cyber","Meteo" };
        public string ImageURL { get; set; }
        
        public MainWindow()
        {
            Main = new Program();
            
            InitializeComponent();
            Program.main();
            foreach (satellite sat in Program.station1.getList())
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = "Sattelite " + sat.GetId();
                satList.Items.Add(newItem);
            }
            foreach (string item in typeOfSatellite)
            {
                  ComboBoxItem newItem = new ComboBoxItem();
                  newItem.Content = item;
                   typeSat.Items.Add(newItem);
                //
            }

        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            //Program Main = new P 
            
        }

        private void satList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void typeSat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
