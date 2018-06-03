using System;
using System.Linq;
using DesignPatterns1.Nodes;

namespace DesignPatterns1.Components.Nodes
{
	public class InputNode : Node
    {
		protected InputNode(string name) : base(name) { }

		protected override void CalculateResult()
		{
			Result = Inputs.First();
		}
	}
}
