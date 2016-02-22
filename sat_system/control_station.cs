using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class control_station
    {
        private LinkedList<satellite> satellites;

        private static control_station _instance;
        protected control_station()
        {

        }
        public static control_station GetControlStation()
        {
            if (_instance == null)
            {
                _instance = new control_station();
            }

            return _instance;
        }
        public void LaunchSatellite(Type satType, int alt = 150, int location = 0, int fuel = 1000)
        {
            if (satType == null)
            {
                return;
            }
          /*  satellite tempSatellite = new typeof(satType)();
            if (tempSatellite != null)
            {
               satellites.AddLast(tempSatellite);
            }*/
           
            
        }
        public void MoveSatellite(int Id, int TgtAlt)
        {
            FindId(Id).SetAltitude(TgtAlt);
        }
        public void ActivateSatellite(int Id)
        {
            FindId(Id).Function();
        }
        // utilities
        public satellite FindId(int id)
        {
            satellite current = satellites.First();
            while (current != null)
            {
                if (current.GetId() == id)
                {
                    return current;
                }
            }
            return null;
                 
        }

        /// temporary
        public string getImgUrl()
        {
            GoogleMapImage img = new GoogleMapImage();
            Point p = new Point(32, 34);
            img.GetUrl(p);
            return img.getPath();
        }
    }
}
