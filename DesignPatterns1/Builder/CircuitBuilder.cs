using System.Collections.Generic;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Factory;
using DesignPatterns1.Repository;

namespace DesignPatterns1.Builder
{
    public class CircuitBuilder : Builder
    {
		private NodeFactory _nodeFactory;
		private List<Node> _builtNodes;
		private EdgeFactory _edgeFactory;

		public CircuitBuilder() : base() {
			this._nodeFactory = new NodeFactory();
			this._builtNodes = new List<Node>();
			this._edgeFactory = new EdgeFactory();
		}

		public override void BuildEdges()
		{
			Dictionary<string, List<string>> nameAndConnectedNodeNames = CircuitDataRepository.Instance.GetEdgesData();
			foreach (KeyValuePair<string, List<string>> entry in nameAndConnectedNodeNames)
			{
				Node startNodeToConnectTo = _builtNodes.Find((Node obj) => obj.Name.Equals(entry.Key));
				entry.Value.ForEach((string connectedNodeName) => { 
					Node endNodeToConnectTo = _builtNodes.Find((Node obj) => obj.Name.Equals(connectedNodeName));
					startNodeToConnectTo.AddEdge(_edgeFactory.Create(startNodeToConnectTo, endNodeToConnectTo));
                    endNodeToConnectTo.IncrementEntries();
				});
			}
		}

		public override void BuildGridNodes()
		{
			Dictionary<string, string> nameAndType = CircuitDataRepository.Instance.GetGridNodesData();
			foreach (KeyValuePair<string, string> entry in nameAndType)
			{
				Node newNode = _nodeFactory.Create(entry.Value);
				newNode.Name = entry.Key;
				_builtNodes.Add(newNode);
				_circuitToBuild.AddGridNodes(newNode);
			}
		}

		public override void BuildInputNodes()
		{
			Dictionary<string, bool> nameAndInput = CircuitDataRepository.Instance.GetInputNodesData();
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
			List<string> names = CircuitDataRepository.Instance.GetOutputNodesData();
			names.ForEach((string name) => {
				Node newNode = _nodeFactory.Create("PROBE");
				newNode.Name = name;
				_builtNodes.Add(newNode);
				_circuitToBuild.AddResultNode(newNode);
			});
		}
	}
}
