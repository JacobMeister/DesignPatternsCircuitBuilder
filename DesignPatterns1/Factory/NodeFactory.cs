using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Nodes;

namespace DesignPatterns1.Factory
{
    public class NodeFactory
	{
		private Dictionary<string, Node> _prototypes = new Dictionary<string, Node>();

		public NodeFactory()
		{
			Initialize();
		}

		private void Initialize() {
			_prototypes["AND"] = new AndNode();
			_prototypes["NOT"] = new NotNode();
			_prototypes["NAND"] = new NotAndNode();
			_prototypes["NOR"] = new NotOrNode();
			_prototypes["OR"] = new OrNode();
			_prototypes["PROBE"] = new OutputNode();
			_prototypes["INPUT"] = new InputNode();
			_prototypes["XOR"] = new XorNode();
            _prototypes["NODE"] = new Node();
        }

		public void RegisterNode(string name, Node node)
		{
			_prototypes[name] = node;
		}

		public Node Create(String type)
		{
			Node prototype = _prototypes[type];
			return prototype.Clone();
		}
	}
}