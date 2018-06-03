using System;
using System.Linq;
using DesignPatterns1.Nodes;

namespace DesignPatterns1.Components.Nodes
{
	public class InputNode : Node
    {
		protected InputNode() : base() { }

		protected override void CalculateResult()
		{
			Result = Inputs.First();
		}
	}
}
