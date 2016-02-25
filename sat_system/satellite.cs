using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

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

        private int Fuel;
        
        private long LastUpdate { get; set; }
        // functions 
        protected satellite(int alt = 150, int pos = 0, int fuel = 1000)
        {
            Altitude = alt;
            Location = pos;
            Fuel = fuel;
            instance++;
            Id = instance;
            FailureTime = DateTime.Now.Subtract(new TimeSpan(1, 0, 0));
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

        public int GetFuel()
        {
            return Fuel;
        }

        private void UpdateLocation()
        {
            DateTime NowTime = new DateTime();
            NowTime = DateTime.Now;
            Location = Math.Abs((Location + rate() * (int)((NowTime.Ticks - LastUpdate) / 1e7))%360);
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
        public string Accept(visitor visitor1)
        {
            return visitor1.VisitSatellite(this);
        }






        public void CalcFuelChange(int AltitudeDiff)
        {
            Fuel = Fuel - Math.Abs(AltitudeDiff) * AltitudeFuelChangeConst;
        }

        public int GetBit()
        {
            return bit;
        }
        public void SetBit(int bitNew)
        {
            bit = bitNew;
        }
        //public abstract class FunctionParams { }
        //private FunctionParams fParams;
        public abstract string Function(SatFunctionParams FuncParams);
        //{
        //    return "";
        //}

        private DateTime FailureTime = new DateTime();
        public void SetUpdateStrategy(int weather)
        {
            ContextBitSubscribe strategy;
            if (weather > 100 /*|| FailureTime.Subtract(DateTime.Now) < new TimeSpan(0, 0, 10)*/)
            {
                strategy = new ContextBitSubscribe(new ProblemStrategy());
                strategy.ContextUpdate(weather,this);
            }
            else
            {
                strategy = new ContextBitSubscribe(new NormalStrategy());
                strategy.ContextUpdate(weather, this);
            }
            
        }
        //public Type ReturnSatType()
        //{
        //    int Index = satList.SelectedIndex;
        //    return typeof(Program.station1.getList()[Index]);
        //}

    }


    class Communication:satellite
    {
        public Communication(int alt, int pos, int fuel) : base(alt, pos, fuel) { }

        public override string Function(SatFunctionParams FuncParams)
        {
            return SatCom(((CommunicationParams)FuncParams).GetPoint1(), ((CommunicationParams)FuncParams).GetPoint2());
        }
        public string SatCom(Point NewPoint1, Point NewPoint2)
        {
            return "location : " + NewPoint1.ToString() + "\n send message to \n location : " + NewPoint2.ToString();
        }


        
    }

    class Photography:satellite
    {
        public Photography(int alt, int pos , int fuel) : base(alt, pos, fuel) { }
        public override string Function(SatFunctionParams FuncParams)
        {
            return GetPicture(((PhotographyParams)FuncParams).location);
        }


        public string GetPicture(Point location)
        {
            GoogleMapImage newImage = new GoogleMapImage();
            newImage.GetUrl(location);
            newImage.DisplayPicture();
            return newImage.getPath();

        }
    }
    class Cyber:satellite
    {
        private Type[] cyberActionTypes;
        public List<string> cyberActionTypesArr = new List<string>();
        public Cyber(int alt, int pos, int fuel): base(alt, pos, fuel)
        {
            cyberActionTypes = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                from assemblyType in domainAssembly.GetTypes()
                                where typeof(CyberFuncClass).IsAssignableFrom(assemblyType) 
                                && !assemblyType.IsAbstract
                                select assemblyType).ToArray();
            foreach (var item in cyberActionTypes)
            {
                string temp = item.ToString();
                int index = temp.IndexOf(".") + 1;
                cyberActionTypesArr.Add(temp.Substring(index));
            }
        }
   
        public override string Function(SatFunctionParams FuncParams)
        {
            LinkedList<ResultSearch> result = new LinkedList < ResultSearch >() ;
            result.AddLast(new ResultSearch());
            if (((CyberParams)FuncParams).URL)
            {
                result.AddLast(new CyberSearchURLDec(result.Last()));
            }
            if (((CyberParams)FuncParams).File)
            {
                result.AddLast(new CyberSearchFileDec(result.Last()));
            }
            return result.Last().CyberFunc((CyberParams)FuncParams);
        }
        public int FindTarget(string path,string Target)
        {

            string fileContent = File.ReadAllText(path);
            return fileContent.IndexOf(Target);


        }

    }
    class Meteo:satellite
    {
        public Meteo(int alt, int pos, int fuel) : base(alt, pos, fuel) { }

        public override string Function(SatFunctionParams met)
        {
            return GetWind();
        }
        public string GetWind()
        {
            Random rnd1 = new Random();

            return "speed wind is: " + rnd1.Next(1,150).ToString();

        }
    }
}
