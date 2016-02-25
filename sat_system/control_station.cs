using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class control_station
    {
        public List<string> satTypesStrArr = new List<string>();
        private ObservableCollection<satellite> satellites;
        private subject Observer;
        public subject getSubject()
        {
            return Observer;
        }
        public ObservableCollection<satellite> getList()
        {
            return satellites;
        }

        private static control_station _instance;
        protected control_station()
        {
            satellites = new ObservableCollection<satellite>();

            var satTypesTemp = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                        from assemblyType in domainAssembly.GetTypes()
                        where typeof(satellite).IsAssignableFrom(assemblyType) && !assemblyType.IsAbstract
                        select assemblyType).ToArray();

            foreach (var item in satTypesTemp)
            {
                if (item != typeof(SovietAdapter))
                {
                    string temp = item.ToString();
                    int index = temp.IndexOf(".") + 1;
                    satTypesStrArr.Add(temp.Substring(index));
                }
                
            }
            Observer = new subject();


        }
        public static control_station GetControlStation()
        {
            if (_instance == null)
            {
                _instance = new control_station();
            }

            return _instance;
        }
        public void LaunchSatellite(string satType, int alt = 150, int location = 0, int fuel = 1000)
        {
            SatelliteFactory newSatellite = new SatelliteFactory();
            satellite newSat = newSatellite.CreateSatellite(satType, alt, location, fuel);
            satellites.Add(newSat);
            
        }
        public void MoveSatellite(int Id, int TgtAlt)
        {
            /*FindId(Id)*/satellites[Id].SetAltitude(TgtAlt);
        }
        public string ActivateSatellite(int Id,SatFunctionParams parmet)
        {
            return satellites[Id].Function(parmet);
        }
        // utilities
        public satellite FindId(int id)
        {
            satellite current = satellites.First();
            foreach (var item in satellites)
            {
                if (item.GetId() == id)
                {
                    return item;
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
        public LinkedList<string> checkBit()
        {
            LinkedList<string> output = new LinkedList<string>();
            foreach (satellite sat in satellites)
            {
                //Console.WriteLine("status of satellite "+ sat.GetId() + "is " + sat.Bit().ToString().ToString());
                output.AddLast("satellite" + sat.GetId() + ": " + sat.GetBit().ToString().ToString());
            }
            return output;
        }
    }
}
