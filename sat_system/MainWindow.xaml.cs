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
        public string ImageURL { get; set; }
        public MainWindow()
        {
            Main = new Program();
            Program.main();
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Program Main = new P 
            string ImageURL = Main.GetImgUrl();
        }
    }
}
