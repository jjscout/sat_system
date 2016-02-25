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
        public SovietAdapter(int alt, int pos, int fuel) : base(alt, pos, fuel) { }
        public virtual string GetPicture(PhotographyParams P)
        {
            return _adaptee.SovietGetPicture(new Point(P.location));
        }
    }
}
