using DesignPatterns1.Components.Base;
using DesignPatterns1.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns1.Components.Circuit
{
    public class Circuit : Component
    {
        private List<Node> _resultNodes;

        public Circuit(string name) : base(name) { }

        public override void CalculateResult()
        {
            _result = 
        }

        public override void FeedResultToNext()
        {
            _outputComponents.ForEach((Component outputComponent) => {
                outputComponent.ReceiveInput()
            });
        }
    }
}
