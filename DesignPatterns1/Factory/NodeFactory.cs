using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Nodes;

namespace DesignPatterns1.Factory
{
	public class NodeFactory
	{
		private Dictionary<String, Type> _types = new Dictionary<string, Type>();

		public NodeFactory()
		{
			Initialize();
		}

		private void Initialize() {
			_types["AND"] = typeof(AndNode);
			_types["NOT"] = typeof(NotNode);
			_types["NAND"] = typeof(NotAndNode);
			_types["NOR"] = typeof(NotOrNode);
			_types["OR"] = typeof(OrNode);
			_types["PROBE"] = typeof(OutputNode);
			_types["INPUT_HIGH"] = typeof(InputNode);
			_types["INPUT_LOW"] = typeof(InputNode);
			_types["XOR"] = typeof(XorNode);
		}

		public void AddNodeType(string name, Type type)
		{
			_types[name] = type;
		}

		public Node Create(String type)
		{
			Type t = _types[type];
			Node c = (Node)Activator.CreateInstance(t);
			return c;
		}
	}
}