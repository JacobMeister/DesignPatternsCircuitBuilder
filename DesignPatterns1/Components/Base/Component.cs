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
		private string _name;
        protected List<Edge> _outputEdges;
		private List<bool> _inputs;
		private long _startTime;
		private long _endTime;
		protected IVisitor _visitor;

		public string Name { get => _name; set => _name = value; }
		public List<bool> Inputs { get => _inputs; private set => _inputs = value; }
		public long StartTime { get => _startTime; private set => _startTime = value; }
		public long EndTime { get => _endTime; private set => _endTime = value; }

		protected Component()
        {
            _outputEdges = new List<Edge>();
            Inputs = new List<bool>();
        }

        public void AddEdge(Edge outputEdge)
        {
            _outputEdges.Add(outputEdge);
        }

        public void ReceiveInput(bool input)
        {
            Inputs.Add(input);
			if (_outputEdges.Count() == Inputs.Count()) {
				CalculateResult();
			}
        }

        public virtual void Reset()
        {
            Name = "";
            _outputEdges.Clear();
            Inputs.Clear();
            StartTime = 0;
            EndTime = 0;
        }

        public virtual void Run(IVisitor visitor)
        {
			SetVisitor(visitor);

            StartTimer();

			CalculateResult();

            EndTimer();

			Accept(visitor);
        }

        protected abstract void CalculateResult();

		private void SetVisitor(IVisitor visitor) {
			this._visitor = visitor;
		}

		protected void StartTimer()
        {
            StartTime = NanoTime();
        }

		protected void EndTimer()
        {
            EndTime = NanoTime();
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
