﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sat_system
{
    abstract class satellite
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

        private int bit = 1;
        
        private int Fuel { get; set; }
        private long LastUpdate { get; set; }
        // functions 
        protected satellite(int alt = 150, int pos = 0, int fuel = 1000)
        {
            Altitude = alt;
            Location = pos;
            Fuel = fuel;
            instance++;
            Id = instance;
        }

        protected satellite(satellite tempSatellite)
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
            return (int) (Math.Sqrt(GravitationalParameter / 
                          Math.Pow(EarthRadius + Altitude, 3)) * 180 / Math.PI);
        }



        


        public void CalcFuelChange(int AltitudeDiff)
        {
            Fuel = Fuel - Math.Abs(AltitudeDiff) * AltitudeFuelChangeConst;
        }

        public int Bit()
        {
            return bit;
        }

        public virtual void Function() { }

        public void Update(int weather)
        {
            Console.WriteLine("satellite " + Id + "update" + "weather is : " + weather);
        }
        
    }


    class Communication:satellite
    {
        public void Function(Point NewPoint1, Point NewPoint2)
        {
            SatCom(NewPoint1, NewPoint2);
        }
        public void SatCom(Point NewPoint1, Point NewPoint2)
        {
            Console.WriteLine("location : ", NewPoint1.ToString(), "send message to location : ", NewPoint2.ToString());
        }
        
    }

    class Photography:satellite
    {
        public void Function(Point location)
        {
            GetPicture(location);
        }


        public virtual void GetPicture(Point location)
        {
            GoogleMapImage newImage = new GoogleMapImage();
            newImage.GetUrl(location);
            newImage.DisplayPicture();

        }
    }
    class Cyber:satellite
    {
        public override void Function() { }
        public int FindTarget(string path,string Target)
        {

            string fileContent = File.ReadAllText(path);
            return fileContent.IndexOf(Target);


        }
    }
    class Meteo:satellite
    {
        public override void Function()
        {
            GetWind();
        }
        public void GetWind()
        {
            Console.WriteLine("wind");

        }
    }
}
