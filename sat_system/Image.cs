using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class Image
    {
        protected string path;

        public Image()
        {
            path = "";
        }

        public string getPath()
        {
            return path;
        }
        public void setPath(string newPath)
        {
            path = newPath;
        }
        public virtual void GetPicture(Point Location)
        {

        }
        public void DisplayPicture()
        {

        }
    }

    class GoogleMapImage : Image
    {
        public void GetUrl(Point Loacation)
        {
           string latlng =  Loacation.getLoaction_X().ToString() + "," + Loacation.getLoaction_X().ToString();
           this.path = "http://maps.googleapis.com/maps/api/staticmap?center=" + latlng +
                        "&zoom=16&size=200x250&maptype=roadmap&markers=color:blue%7Clabel:S%7C" +
                         latlng + "&sensor=false"; 
        }
    }
}
