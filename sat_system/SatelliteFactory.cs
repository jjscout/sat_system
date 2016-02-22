using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class SatelliteFactory
    {
        
        public satellite CreateSatellite(Type typesatellite)
        {
            satellite newSatellite;
            if (typesatellite == typeof(Communication))
            {
                newSatellite = new Communication();
            }
            else if (typesatellite == typeof(Photography))
            {
                newSatellite = new Photography();
            }
            else if (typesatellite == typeof(Cyber))
            {
                newSatellite = new Cyber();
            }
            else if (typesatellite == typeof(Meteo))
            {
                newSatellite = new Meteo();
            }
            else
            {
                newSatellite = null; 
            }
            return newSatellite;
        }

    }
}
