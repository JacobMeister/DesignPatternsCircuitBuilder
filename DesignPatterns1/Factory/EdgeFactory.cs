using DesignPatterns1.Components.Edges;
using DesignPatterns1.Components.Nodes;

namespace DesignPatterns1.Factory
{
    public class EdgeFactory
    {
		public Edge Create(Node startNode, Node endNode) {
			return new Edge(startNode, endNode);
		}
    }
}
