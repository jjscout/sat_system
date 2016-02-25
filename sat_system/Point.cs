using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class Point
    {
         int Location_X;
         int Location_Y;
        public Point(int X,int Y)
        {
            Location_X = X;
            Location_Y = Y;
        }
        public Point(Point P)
        {
            Location_X = P.getLoaction_X();
            Location_Y = P.getLoaction_Y();
        }
        public int getLoaction_X()
        {
            return Location_X;
        }
        public int getLoaction_Y()
        {
            return Location_Y;
        }
        public void setLoaction_X(int newLocation)
        {
             Location_X = newLocation;
        }
        public void setLoaction_Y(int newLocation)
        {
            Location_Y = newLocation;
        }
        public override string ToString()
        {
            return " x: " + Location_X.ToString() + " y: " + Location_Y.ToString() + " ";
        }
    }
}
