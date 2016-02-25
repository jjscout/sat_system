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
//using System.ComponentModel;

namespace sat_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private Program Main;
        //public readonly string[] typeOfSatellite =  { "Communication", "Photography","Cyber","Meteo" };
        public string ImageURL { get; set; }

        public MainWindow()
        {
            Main = new Program();

            InitializeComponent();
            Program.main();


            //satList.Initialized;

            foreach (string item in Program.station1.satTypesStrArr)
            {
                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = item;
                typeSat.Items.Add(newItem);
                //
            }

        }

        private void Launch_Click(object sender, RoutedEventArgs e)
        {
            Program Main = new Program();

            Program.station1.LaunchSatellite(typeSat.Text, int.Parse(altitude.Text), int.Parse(degree.Text), int.Parse(fuel.Text));
            UpdateListSatellite();
        }

        private void satList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            displayDataSat();
        }

        private void typeSat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void UpdateListSatellite()
        {
            int current = 0 ;
            string currentSel;
            if (satList.SelectedItem != null)
            {
                currentSel = satList.SelectedItem.ToString();
                current = int.Parse(currentSel.Substring(currentSel.LastIndexOf(" ") ));
            }
            satList.Items.Clear();
            foreach (satellite sat in Program.station1.getList())
            {

                ComboBoxItem newItem = new ComboBoxItem();
                newItem.Content = "Sattelite " + sat.GetId();
                if (sat.GetId() == current)
                {
                    satList.SelectedItem =  newItem;
                }
                satList.Items.Add(newItem);
            }
        }

        private void displayDataSat()
        {
            int location = satList.SelectedIndex;
            if (location < 1 )
            {
                location = 1;
            }
           
            satellite sat = Program.station1.getList()[location];
            altitude.Text = sat.GetAltitude().ToString();
            fuel.Text = sat.GetFuel().ToString();
            degree.Text = sat.getLocation().ToString();

        }


        private void update_Click(object sender, RoutedEventArgs e)
        {
            Program.station1.MoveSatellite(satList.SelectedIndex, int.Parse(altitude.Text));
            displayDataSat();
        }

        private void bit_Click(object sender, RoutedEventArgs e)
        {
            labelBit.Content = "";
            foreach (var item in Program.station1.checkBit())
            {
                labelBit.Content += item + "\n";
            }

        }

        private void buttonObserv_Click(object sender, RoutedEventArgs e)
        {
            Program.station1.getSubject().Notify();
            observ.Content = "";
            foreach (var item in subject.message)
            {
                observ.Content += item + "\n";
            }

        }

        private void addObserver_Click(object sender, RoutedEventArgs e)
        {
            Program.station1.getSubject().Subscribe(Program.station1.getList()
                [satList.SelectedIndex]);
        }

        private void removeObserver_Click(object sender, RoutedEventArgs e)
        {
            Program.station1.getSubject().Unsubscribe(Program.station1.getList()
                [satList.SelectedIndex]);
        }

        private void action_Click(object sender, RoutedEventArgs e)
        {
            int Index = satList.SelectedIndex;

            if (Program.station1.getList()[Index].GetType() == typeof(Photography))
            {
                ActivatePhoto win2 = new ActivatePhoto(Index);
                win2.Show();
            }
            else if (Program.station1.getList()[Index].GetType() == typeof(Communication))
            {
                ActivateComm win2 = new ActivateComm(Index);
                win2.Show();
            }
            else if (Program.station1.getList()[Index].GetType() == typeof(Cyber))
            {
                ActivateCyber win2 = new ActivateCyber(Index);
                win2.Show();
            }
            else if (Program.station1.getList()[Index].GetType() == typeof(Meteo))
            {
                ActivateMeteo win2 = new ActivateMeteo(Index);
                win2.Show();
            }

        }

        private void degree_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void visitorfuel_Click(object sender, RoutedEventArgs e)
        {
            visitor v1 = new fuelVisitor();
            labelBit.Content =  Program.station1.getList()[satList.SelectedIndex].Accept(v1);
        }
    }
}
