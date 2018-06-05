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
		private long _startTime;
		private long _endTime;
		protected IVisitor _visitor;
        
		public long StartTime { get => _startTime; protected set => _startTime = value; }
		public long EndTime { get => _endTime; protected set => _endTime = value; }
       

        protected Component()
        {
        }

        public virtual void Reset()
        {
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

        public virtual void Accept(IVisitor visitor)
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
