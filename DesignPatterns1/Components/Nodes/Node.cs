using System.Collections.Generic;
using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Edges;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Visitor;

namespace DesignPatterns1.Nodes
{
    public abstract class Node : Component
    {
		private bool _result;

		protected Node() : base()
		{
			Result = false;
		}

		public bool Result { get => _result; set => _result = value; }

		public override void Reset()
		{
			base.Reset();
			Result = false;
        }

		public override void Run(IVisitor visitor)
		{
			base.Run(visitor);
			FeedResultToNext();
		}

		protected void FeedResultToNext()
		{
			_outputEdges.ForEach((Edge outputEdge) => {
				outputEdge.GetEndComponent().ReceiveInput(Result);
			});
		}

		public Node Clone() {
			return (Node)this.MemberwiseClone();
		}
    }
}
