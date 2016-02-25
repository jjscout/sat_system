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
        public static LinkedList<string> message;
        private LinkedList<satellite> observers;
        public subject ( )
        {
            Random rnd1 = new Random();
            message = new LinkedList<string>();
            observers = new LinkedList<satellite>();
            weather = (int)(rnd1.Next(1000));
        }

        public void Subscribe(satellite observer)
        {
            observers.AddLast(observer);
        }


        public void Unsubscribe(satellite observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            Random rnd1 = new Random();
            weather = (int)(rnd1.Next(1,150));
            message.Clear();
            foreach (satellite item in observers)
            {
                item.SetUpdateStrategy(weather);
                
            };
        }
    }
}

