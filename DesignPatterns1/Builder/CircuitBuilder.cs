using System;
using System.Collections.Generic;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Factory;
using DesignPatterns1.Nodes;
using DesignPatterns1.Repository;

namespace DesignPatterns1.Builder
{
	public class CircuitBuilder : Builder
    {
		private NodeFactory _nodeFactory;
		private List<Node> _builtNodes;

		public CircuitBuilder(CircuitDataRepository circuitDataRepository) : base(circuitDataRepository) {
			this._nodeFactory = new NodeFactory();
			this._builtNodes = new List<Node>();
		}

		public override void BuildEdges()
		{
			Dictionary<string, List<string>> nameAndConnectedNodeNames = _circuitDataRepository.GetEdgesData();
			foreach (KeyValuePair<string, List<string>> entry in nameAndConnectedNodeNames)
			{
				Node startNodeToConnectTo = _builtNodes.Find((Node obj) => obj.Name.Equals(entry.Key));
				entry.Value.ForEach((string connectedNodeName) => { 
					Node endNodeToConnectTo = _builtNodes.Find((Node obj) => obj.Name.Equals(connectedNodeName));
					startNodeToConnectTo.AddEdge(_edgeFactory.Create(startNodeToConnectTo, endNodeToConnectTo));
				});
			}
		}

		public override void BuildGridNodes()
		{
			Dictionary<string, string> nameAndType = _circuitDataRepository.GetGridNodesData();
			foreach (KeyValuePair<string, string> entry in nameAndType)
			{
				Node newNode = _nodeFactory.Create(entry.Value);
				newNode.Name = entry.Key;
				_builtNodes.Add(newNode);
			}
		}

		public override void BuildInputNodes()
		{
			Dictionary<string, bool> nameAndInput = _circuitDataRepository.GetInputNodesData();
			foreach (KeyValuePair<string, bool> entry in nameAndInput)
			{
				Node newNode = _nodeFactory.Create("INPUT");
				newNode.Name = entry.Key;
				newNode.Inputs.Add(entry.Value);
				_builtNodes.Add(newNode);
				_circuitToBuild.AddEntryNodes(newNode);
			}
		}

		public override void BuildOutputNodes()
		{
			List<string> names = _circuitDataRepository.GetOutputNodesData();
			names.ForEach((string name) => {
				Node newNode = _nodeFactory.Create('OUTPUT');
				newNode.Name = name;
				_builtNodes.Add(newNode);
				_circuitToBuild.AddResultNode(newNode);
			});
		}

		public override Circuit GetResult()
		{
			return _circuitToBuild;
		}
	}
}
