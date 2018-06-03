using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Nodes;

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
			_prototypes["NOT"] = typeof(NotNode);
			_prototypes["NAND"] = typeof(NotAndNode);
			_prototypes["NOR"] = typeof(NotOrNode);
			_prototypes["OR"] = typeof(OrNode);
			_prototypes["PROBE"] = typeof(OutputNode);
			_prototypes["INPUT_HIGH"] = typeof(InputNode);
			_prototypes["INPUT_LOW"] = typeof(InputNode);
			_prototypes["XOR"] = typeof(XorNode);
		}

		public void RegisterNode(string name, Node node)
		{
			_prototypes[name] = type;
		}

		public Node Create(String type)
		{
			Node prototype = _prototypes[type];
			return prototype.Clone();
		}
	}
}