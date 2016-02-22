using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    class subject
    {
        private int weather;
        private List<IObserver<satellite>> observers;
        public void Subscribe(IObserver<satellite> observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver<satellite> observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (satellite item in observers)
            {
                item.Update(weather);
            };
        }
    }
}

