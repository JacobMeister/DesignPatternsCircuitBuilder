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

		protected Node(string name) : base(name)
		{
			Result = false;
		}

		public bool Result { get => _result; private set => _result = value; }

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
    }
}
