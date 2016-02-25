using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class SatelliteFactory
    {
        
        public satellite CreateSatellite(string typesatellite,int alt,int location,int fuel)
        {
            satellite newSatellite;
            if (typesatellite == "Communication")
            {
                newSatellite = new Communication(alt,location,fuel);
            }
            else if (typesatellite == "Photography")
            {
                newSatellite = new Photography(alt, location, fuel);
            }
            else if (typesatellite == "Cyber")
            {
                newSatellite = new Cyber(alt, location, fuel);
            }
            else if (typesatellite == "Meteo")
            {
                newSatellite = new Meteo(alt, location, fuel);
            }
            else
            {
                newSatellite = null; 
            }
            return newSatellite;
        }

    }
}
