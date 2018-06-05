using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Nodes;

namespace DesignPatterns1.Components.Edges
{
    public class Edge
    {
        private Node _startComponent;
        private Node _endComponent;

        public Edge(Node startComponent, Node endComponent)
        {
            _startComponent = startComponent;
            _endComponent = endComponent;
        }

        public Node GetEndComponent()
        {
            return _endComponent;
        }


    }
}
