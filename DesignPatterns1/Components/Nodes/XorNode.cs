using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Nodes
{
	public class XorNode : Node
	{
		protected XorNode() : base() { }

		protected override void CalculateResult()
		{
			Result = (Inputs[0] != Inputs[1]);
		}
	}
}
