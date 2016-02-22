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
        public LinkedList<satellite> getList()
        {
            return satellites;
        }

        private static control_station _instance;
        protected control_station()
        {
            satellites = new LinkedList<satellite>();
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
            SatelliteFactory newSatellite = new SatelliteFactory();
            satellite newSat = newSatellite.CreateSatellite(satType);
            satellites.AddLast(newSat);
            
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
        public void checkBit()
        {
            foreach (satellite sat in satellites)
            {
                Console.WriteLine("status of satellite "+ sat.GetId() + "is " + sat.Bit().ToString().ToString());
            }
        }
    }
}
