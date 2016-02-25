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

namespace sat_system
{
    /// <summary>
    /// Interaction logic for ActivateCyber.xaml
    /// </summary>
    public partial class ActivateCyber : Window
    {
        private int Id;
        CyberParams param;
        public ActivateCyber(int id)
        {
            InitializeComponent();
            Id = id;
            
        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            param = new CyberParams(filePath.Text, fileName.Text, urlPath.Text, searchFile.IsChecked.Value/*(filePath.Text != "")*/, searchUrl.IsChecked.Value/*urlPath.Text != ""*/);
            output.Text = Program.station1.ActivateSatellite(Id, param);
        }

        private void searchFile_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
