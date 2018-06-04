using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Nodes;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns1.Components.Circuit
{
    public class Circuit : Component
    {
        private List<Node> _resultNodes = new List<Node>();
		private List<Node> _entryNodes = new List<Node>();
		private List<Node> _gridNodes = new List<Node>();

		public List<Node> ResultNodes { get => _resultNodes; private set => _resultNodes = value; }
		public List<Node> EntryNodes { get => _entryNodes; private set => _entryNodes = value; }
        public List<Node> GridNodes { get => _gridNodes; set => _gridNodes = value; }

        public Circuit() : base()
		{
			ResultNodes = new List<Node>();
			EntryNodes = new List<Node>();
		}

        protected override void CalculateResult()
        {
			EntryNodes.ForEach((Node obj) => {
				obj.Run(_visitor);
			});
        }

		public void AddResultNode(Node resultNode) {
			ResultNodes.Add(resultNode);
		}

		public void AddEntryNodes(Node entryNode) {
			EntryNodes.Add(entryNode);
		}

		public void AddGridNodes(Node gridNode) {
			GridNodes.Add(gridNode);
		}
		
		public void ChangeInputOf(string nameOfNode, bool input) {
			EntryNodes.First(node => node.Name.Equals(nameOfNode))
			           .Result = input;
		}

		public override void Accept(Visitor.IVisitor visitor) 
		{
			visitor.Visit(this);
		}
    }
}
