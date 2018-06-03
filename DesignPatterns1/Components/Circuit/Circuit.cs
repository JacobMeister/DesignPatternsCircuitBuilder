using DesignPatterns1.Components.Base;
using DesignPatterns1.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Components.Circuit
{
    public class Circuit : Component
    {
        private List<Node> _resultNodes;
		private List<Node> _entryNodes;

		public List<Node> ResultNodes { get => _resultNodes; private set => _resultNodes = value; }
		public List<Node> EntryNodes { get => _entryNodes; private set => _entryNodes = value; }

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

		public void ChangeInputOf(string nameOfNode, bool input) {
			EntryNodes.First(node => node.Name.Equals(nameOfNode))
			           .Result = input;
		}
    }
}
