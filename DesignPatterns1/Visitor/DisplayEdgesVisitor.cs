using System;
using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Circuit;
using DesignPatterns1.Components.Nodes;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Visitor
{
	public class DisplayEdgesVisitor : IVisitor
    {
		private IOutputHandler _outputHandler;

		public DisplayEdgesVisitor(IOutputHandler outputHandler)
        {
			_outputHandler = outputHandler;
        }

		public void Visit(Component visitee)
		{
            SendOutput(visitee.Name, "Component", GetConnectionsString(visitee));
        }

		public void Visit(Circuit visitee)
		{
            SendOutput(visitee.Name, "Circuit", GetConnectionsString(visitee));
        }

		public void Visit(Node visitee)
		{
            SendOutput(visitee.Name, "Node", GetConnectionsString(visitee));
		}

		public void Visit(AndNode visitee)
		{
			SendOutput(visitee.Name, "AndNode", GetConnectionsString(visitee));
		}

		public void Visit(NotAndNode visitee)
		{
			SendOutput(visitee.Name, "NotAndNode", GetConnectionsString(visitee));
		}

		public void Visit(NotNode visitee)
		{
			SendOutput(visitee.Name, "NotNode", GetConnectionsString(visitee));
		}

		public void Visit(OrNode visitee)
		{
			SendOutput(visitee.Name, "OrNode", GetConnectionsString(visitee));
		}

		public void Visit(NotOrNode visitee)
		{
			SendOutput(visitee.Name, "NotOrNode", GetConnectionsString(visitee));
		}

		public void Visit(XorNode visitee)
		{
			SendOutput(visitee.Name, "XorNode", GetConnectionsString(visitee));
		}

		public void Visit(InputNode visitee)
		{
			SendOutput(visitee.Name, "Input", GetConnectionsString(visitee));
		}

		public void Visit(OutputNode visitee)
		{
			SendOutput(visitee.Name, "Probe", GetConnectionsString(visitee));
		}

		private string GetConnectionsString(Component component) {
			string connections = "";
			if (component.OutputEdges.Count == 0)
			{
				connections = "No Connections";
			}
			else
			{
                component.OutputEdges.ForEach((edge) => {
					connections += " " + edge.GetEndComponent().Name + ", ";
				});
				connections.Trim();
				connections = connections.Remove(connections.Length - 1);
			}
			return connections;
		}

		private void SendOutput(string nodeName, string typeName, string connections) {
			_outputHandler.Write(nodeName + " (" + typeName + ") connects to: " + connections);
		}
	}
}
