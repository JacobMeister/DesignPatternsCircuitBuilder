using System.Collections.Generic;
using System.Linq;
using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Edges;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Visitor;

namespace DesignPatterns1.Components.Nodes
{
    public class Node : Component
    {
		private bool _result;
        private int _entryAmount;
        private List<Edge> outputEdges;
        private List<bool> _inputs;
        private string _name;

        public string Name { get => _name; set => _name = value; }
        public List<bool> Inputs { get => _inputs; private set => _inputs = value; }
        public List<Edge> OutputEdges { get => outputEdges; set => outputEdges = value; }
        public int EntryAmount { get => _entryAmount; set => _entryAmount = value; }

        public bool Result { get => _result; set => _result = value; }

        public Node() : base()
		{
			Result = false;
			EntryAmount = 0;
            OutputEdges = new List<Edge>();
            Inputs = new List<bool>();
            EntryAmount = 0;
        }

        public void IncrementEntries()
        {
            this.EntryAmount++;
        }

        public void AddEdge(Edge outputEdge)
        {
            if (outputEdge != null)
            {
                OutputEdges.Add(outputEdge);
            }
        }

        public void ReceiveInput(bool input)
        {
            Inputs.Add(input);
        }

        public bool CanBeResolved()
        {
            if (Inputs.Count() >= EntryAmount)
            {
                return true;
            }
            return false;
        }

        public override void Reset()
		{
			base.Reset();
            Inputs.Clear();
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
