using System;
using System.Collections.Generic;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Nodes;

namespace DesignPatterns1.Factory
{
	public class NodeFactory
	{
		private Dictionary<String, Type> _types;

		public NodeFactory()
		{
			Initialize();
		}

		private void Initialize() {
			_types["AND"] = typeof(AndNode);
			_types["NOT"] = typeof(NotNode);
			_types["NOTAND"] = typeof(NotAndNode);
			_types["NOTOR"] = typeof(NotOrNode);
			_types["OR"] = typeof(OrNode);
			_types["OUTPUT"] = typeof(OutputNode);
			_types["INPUTHIGH"] = typeof(InputHighNode);
			_types["INPUTLOW"] = typeof(InputLowNode);
			_types["XOR"] = typeof(XorNode);
		}

		public void AddNodeType(string name, Type type)
		{
			_types[name] = type;
		}

		public INode CreateFromName(String type)
		{
			Type t = _types[type];
			INode c = (INode)Activator.CreateInstance(t);
			return c;
		}
	}
}