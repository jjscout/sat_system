using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    abstract class SovietSattelite
    {
        // constants
        private const double GravitationalParameter = 3.986e14;
        private const int EarthRadius = 6378;
        private const int AltitudeFuelChangeConst = 1;
        // statics
        static int instance = 0;
        // properties
        private int Id;

        private int Altitude;

        private int Fuel { get; set; }
        private long LastUpdate { get; set; }
        // functions 
        protected SovietSattelite(int alt = 150, int pos = 0, int fuel = 1000)
        {
            Altitude = alt;
            Location = pos;
            Fuel = fuel;
            instance++;
            Id = instance;
        }

        protected SovietSattelite(SovietSattelite tempSatellite)
        {
            Altitude = tempSatellite.Altitude;
            Location = tempSatellite.Location;
            Fuel = tempSatellite.Fuel;
            Id = instance;
        }
        public int GetAltitude()
        {
            return Altitude;
        }
        public void SetAltitude(int val)
        {
            CalcFuelChange(Altitude - val);
            Altitude = val;
        }
        public int GetId()
        {
            return Id;
        }
        private void UpdateLocation()
        {
            DateTime NowTime = new DateTime();
            Location = Location + rate() * (int)((NowTime.Ticks - LastUpdate) / 1e7);
            LastUpdate = NowTime.Ticks;
        }
        private int Location;

        public int getLocation()
        {
            UpdateLocation();
            return Location;
        }

        public void setLocation(int value)
        {
            Location = value;
        }



        private int rate()
        {
            return (int)(Math.Sqrt(GravitationalParameter /
                          Math.Pow(EarthRadius + Altitude, 3)) * 180 / Math.PI);
        }






        public void CalcFuelChange(int AltitudeDiff)
        {
            Fuel = Fuel - Math.Abs(AltitudeDiff) * AltitudeFuelChangeConst;
        }

        public int Bit()
        {
            return 1;
        }


    }
    class SovietPhotography : SovietSattelite
    {


        public string SovietGetPicture(Point location)
        {
            GoogleMapImage newImage = new GoogleMapImage();
            newImage.GetUrl(location);
            newImage.DisplayPicture();
            return newImage.getPath();
        }
    }
}
