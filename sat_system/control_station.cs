using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    enum SatType
    {
        
    }
    class control_station
    {
        private LinkedList<satellite> satellites; 
        
        public void LaunchSatellite(Type satellite, int alt = 150, int location = 0, int fuel = 1000)
        {
            if (satellite == null)
            {
                return;
            }
            satellites.AddLast(new satellite(alt, location, fuel));
            
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
