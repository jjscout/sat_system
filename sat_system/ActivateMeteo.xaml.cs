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
    /// Interaction logic for ActivateMeteo.xaml
    /// </summary>
    /// 
    public partial class ActivateMeteo : Window
    {
        private int Id;
        CyberParams param;
        public ActivateMeteo(int id)
        {
            InitializeComponent();
            Id = id;//MainWindow.satList.SelectedIndex;
            meteoOut.Text = Program.station1.ActivateSatellite(Id, param);
        }
    }
}
