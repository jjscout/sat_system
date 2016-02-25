using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sat_system
{
    abstract class StrategyBitSubcribe
    {
        public abstract void BitSubcribeInteface();
        public abstract void Update(int weather, satellite sat);

    }

    class NormalStrategy: StrategyBitSubcribe
    {
        public override void BitSubcribeInteface()
        {
            
        }
        public override void Update(int weather, satellite sat)
        {
            subject.message.AddLast("satellite " + sat.GetId() + "update" + "weather is : " + weather.ToString());
        }
    }
    class ProblemStrategy: StrategyBitSubcribe
    {
        public override void BitSubcribeInteface()
        {

        }
        public override void Update(int weather, satellite sat)
        {
            subject.message.AddLast("satellite " + sat.GetId() + ":cyber cyber cyber");
        }
    }

    class ContextBitSubscribe
    {
        private StrategyBitSubcribe _strategy;
        public ContextBitSubscribe(StrategyBitSubcribe strategy)
        {
            _strategy = strategy;
        }
        public void ContextUpdate(int weather, satellite sat)
        {
            _strategy.Update(weather, sat);
        }
    }
}
