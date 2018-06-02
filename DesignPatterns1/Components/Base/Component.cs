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
        private List<bool> _inputs;
        private bool _result;
        private long _startTime;
        private long _endTime;

        public Component(string name)
        {
            _name = name;
        }

        public void AddOutputComponent(Component outputComponent)
        {
            _outputComponents.Add(outputComponent);
        }

        public void ReceiveInput(bool input)
        {
            _inputs.Add(input);
        }

        public void Reset()
        {
            _name = "";
            _outputComponents.Clear();
            _inputs.Clear();
            _result = false;
            _startTime = 0;
            _endTime = 0;
        }

        public void Run()
        {
            StartTime();

            CalculateResult();

            FeedResultToNext();

            EndTime();
        }

        public bool CalculateResult()
        {
            return false;
        }

        public void FeedResultToNext()
        {
            _outputComponents.ForEach((Component component) => {
                component.ReceiveInput(_result);
            });
        }

        public void StartTime()
        {
            _startTime = NanoTime();
        }

        public void EndTime()
        {
            _endTime = NanoTime();
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
