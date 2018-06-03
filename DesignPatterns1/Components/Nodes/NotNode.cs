using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns1.Interfaces;

namespace DesignPatterns1.Nodes
{
	public class NotNode : Node
	{
		protected NotNode(string name) : base(name) { }

		protected override void CalculateResult()
		{
			Result = !Inputs.First();
		}
	}
}
