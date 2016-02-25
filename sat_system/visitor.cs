using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    abstract class visitor
    {
        public abstract string VisitSatellite(satellite concreteElementA);
    }
    class fuelVisitor : visitor
    {
        public override string VisitSatellite(satellite concreteElementA)
        {
            string state = "bad";
            if (concreteElementA.GetFuel() > 0)
            {
                state = "good";
            }
            return "the state of fuel is :" + state;
        }
    }
}
