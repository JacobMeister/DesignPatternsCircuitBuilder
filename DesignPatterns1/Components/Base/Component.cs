using DesignPatterns1.Visitor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Nodes.Base
{
    public abstract class Component
    {

        private string _name;
        private string _typeName;
        private List<Component> _outputComponents;
        private bool _result;
        private long _startTime;
        private long _endTime;




        public Component(string name)
        {

        }

        public void AddOutputComponent(Component outputComponent)
        {

        }

        public void ReceiveInput(bool input)
        {

        }

        public void Reset()
        {

        }

        override
        public string ToString()
        {
            return "";
        }

        public bool CalculateResult()
        {
            return false;
        }

        public void FeedResultToNext()
        {

        }

        public void StartTime()
        {

        }

        public void EndTime()
        {

        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected long NanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}
