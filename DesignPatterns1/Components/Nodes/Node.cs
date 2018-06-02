using System.Collections.Generic;
using DesignPatterns1.Components.Base;
using DesignPatterns1.Components.Edges;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Nodes
{
    public abstract class Node : Component
    {
        protected bool _result;

        public Node(string name) : base(name)
        {
            _result = false;
        }

        public override void FeedResultToNext()
        {
            _outputEdges.ForEach((Edge outputEdge) => {
                outputEdge.GetEndComponent().ReceiveInput(_result);
            });
        }

        public override void Reset()
        {
            base.Reset();
            _result = false;
        }
    }
}
