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

        public Circuit(string name) : base(name) { }

        public override void CalculateResult()
        {
			_entryNodes.ForEach((Node obj) => {
				obj.Run(_visitor);
			});
        }


		public void AddResultNode(Node resultNode) {
			_resultNodes.Add(resultNode);
		}

		public void AddEntryNodes(Node entryNode) {
			_entryNodes.Add(entryNode);
		}
    }
}
