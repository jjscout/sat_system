using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class SovietAdapter: Photography
    {
        private SovietPhotography _adaptee = new SovietPhotography();

        public override void GetPicture(Point P)
        {
            _adaptee.SovietGetPicture(P);
        }
    }
}
