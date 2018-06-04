using System.Collections.Generic;
using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Edges;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Visitor;

namespace DesignPatterns1.Components.Nodes
{
    public class Node : Component
    {
		private bool _result;

		public Node() : base()
		{
			Result = false;
			EntryAmount = 0;
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
			OutputEdges.ForEach((Edge outputEdge) => {
				outputEdge.GetEndComponent().ReceiveInput(Result);
                if (outputEdge.GetEndComponent().CanBeResolved())
                {
                    outputEdge.GetEndComponent().Run(_visitor);
                }
			});
		}

		public virtual Node Clone()
        {
            return new Node();
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected override void CalculateResult()
        {
            Inputs.ForEach(input =>
            {
                Result = input;
            });
        }
    }
}
