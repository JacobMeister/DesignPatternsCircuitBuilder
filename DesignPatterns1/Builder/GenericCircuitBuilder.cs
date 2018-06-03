using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Factory;
using DesignPatterns1.Nodes;

namespace DesignPatterns1.Builder
{
	public class GenericCircuitBuilder : Builder
    {
		private Circuit _circuitToBuild;
		private NodeFactory _nodeFactory;
		private EdgeFactory _edgeFactory;
		private List<Node> _builtNodes;

		public GenericCircuitBuilder() {
			this._nodeFactory = new NodeFactory();
			this._edgeFactory = new EdgeFactory();
			this._circuitToBuild = new Circuit();
			this._builtNodes = new List<Node>();
		}


		public override void BuildEdges(Dictionary<string, List<string>> nameAndConnectedNodeNames)
		{
			foreach (KeyValuePair<string, List<string>> entry in nameAndConnectedNodeNames)
			{
				Node startNodeToConnectTo = _builtNodes.Find((Node obj) => obj.Name.Equals(entry.Key));
				entry.Value.ForEach((string connectedNodeName) => { 
					Node endNodeToConnectTo = _builtNodes.Find((Node obj) => obj.Name.Equals(connectedNodeName));
					startNodeToConnectTo.AddEdge(_edgeFactory.Create(startNodeToConnectTo, endNodeToConnectTo));
				});
			}
		}

		public override void BuildNodes(Dictionary<string, string> nameAndType)
		{
			foreach (KeyValuePair<string, string> entry in nameAndType)
			{
				Node newNode = _nodeFactory.Create(entry.Value);
				newNode.Name = entry.Key;
				_builtNodes.Add(newNode);
			}
		}

		public override Circuit GetResult()
		{
			return _circuitToBuild;
		}
	}
}
