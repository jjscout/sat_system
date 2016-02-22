using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class Program
    {
        public static control_station station1;
         
        public static void main()
        {
            station1 = control_station.GetControlStation();
            station1.LaunchSatellite(typeof(Photography));
            



        }

    }
}
