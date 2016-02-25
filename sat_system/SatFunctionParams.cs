using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    abstract class SatFunctionParams
    {
    }

    class CommunicationParams: SatFunctionParams
    {
        private Point NewPoint1;
        private Point NewPoint2;

        public CommunicationParams(int x1, int y1, int x2, int y2)
        {
            NewPoint1 = new Point(x1, y1);
            NewPoint2 = new Point(x2, y2);
        }
        public CommunicationParams(Point P1, Point P2)
        {
            NewPoint1 = P1;
            NewPoint2 = P2;
        }

        public void setPoint1(int x, int y)
        {
            NewPoint1.setLoaction_X(x);
            NewPoint1.setLoaction_Y(y);
        }
        public void setPoint1(Point P)
        {
            NewPoint1.setLoaction_X(P.getLoaction_X());
            NewPoint1.setLoaction_Y(P.getLoaction_Y());
        }
        public Point GetPoint1()
        {
            return NewPoint1;
        }
        public void setPoint2(int x, int y)
        {
            NewPoint1.setLoaction_X(x);
            NewPoint1.setLoaction_Y(y);
        }
        public void setPoint2(Point P)
        {
            NewPoint1.setLoaction_X(P.getLoaction_X());
            NewPoint1.setLoaction_Y(P.getLoaction_Y());
        }
        public Point GetPoint2()
        {
            return NewPoint2;
        }
    }
    class PhotographyParams : SatFunctionParams
    {
        public Point location { get; set; }
        public PhotographyParams(Point p)
        {
            location = p;
        }
        public PhotographyParams(int x, int y)
        {
            location = new Point(x, y);
        }
    }
    class CyberParams : SatFunctionParams
    {
        public string Path { get; set; }
        public string Name { get; set; }
        public string PathUrl { get; set; }
        public bool File { get; set; }
        public bool URL { get; set; }

        public CyberParams(string path , string name , string urlPa, bool file, bool url)
        {
            Path = path;
            Name = name;
            File = file;
            URL = url;
            PathUrl = urlPa;
        }

    }
    class MeteoParams : SatFunctionParams
    {

    }
}
