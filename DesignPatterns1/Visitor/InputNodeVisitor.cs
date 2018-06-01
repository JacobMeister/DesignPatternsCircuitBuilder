using System;
using DesignPatterns1.Controller;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Nodes;

namespace DesignPatterns1.Visitor
{
	public class InputNodeVisitor: IVisitor
    {
		private CircuitController circuitController;

		public InputNodeVisitor(CircuitController circuitController)
		{
			this.circuitController = circuitController;
		}

		public void Visit(InputLowNode inputLow)
		{
			throw new NotImplementedException();
		}

		public void Visit(InputHighNode inputHigh)
		{
			throw new NotImplementedException();
		}

		public void Visit(INode visitee)
		{
			throw new NotImplementedException();
		}
	}
}
