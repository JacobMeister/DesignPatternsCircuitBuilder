using DesignPatterns1.Components.Base;
using DesignPatterns1.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Components.Edges
{
    public class Edge
    {
        private Component _startComponent;
        private Component _endComponent;

        public Edge(Component startComponent, Component endComponent)
        {
            _startComponent = startComponent;
            _endComponent = endComponent;
        }

        public Component GetEndComponent()
        {
            return _endComponent;
        }
    }
}
