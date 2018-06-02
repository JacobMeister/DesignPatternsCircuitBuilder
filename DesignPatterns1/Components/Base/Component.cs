using DesignPatterns1.Components.Edges;
using DesignPatterns1.Visitor;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Components.Base
{
    public abstract class Component
    {
        protected string _name;
        protected string _typeName;
        protected List<Edge> _outputEdges;
        protected List<bool> _inputs;
        protected long _startTime;
        protected long _endTime;

        public Component(string name)
        {
            _name = name;
            _typeName = "";
            _outputEdges = new List<Edge>();
            _inputs = new List<bool>();
        }

        public void AddEdge(Edge outputEdge)
        {
            _outputEdges.Add(outputEdge);
        }

        public void ReceiveInput(bool input)
        {
            _inputs.Add(input);
        }

        public virtual void Reset()
        {
            _name = "";
            _outputEdges.Clear();
            _inputs.Clear();
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

        public abstract void CalculateResult();

        public abstract void FeedResultToNext();

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
