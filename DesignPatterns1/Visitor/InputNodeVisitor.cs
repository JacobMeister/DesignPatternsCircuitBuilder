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
			String s = inputLow.GetLiteralName();
			InputLowNode tempnode = new InputLowNode();
			tempnode.SetOutputNodes(inputLow.GetOutputNodes());
			tempnode.SetLiteralName(inputLow.GetLiteralName());
			circuitController.GetNodes().Remove(s);
			circuitController.GetNodes().Add(s, tempnode);
			circuitController.GetInputNodes().Remove(s);
			circuitController.GetInputNodes().Add(s, tempnode);
		}

		public void Visit(InputHighNode inputHigh)
		{
			String s = inputHigh.GetLiteralName();
			InputHighNode tempnode = new InputHighNode();
			tempnode.SetOutputNodes(inputHigh.GetOutputNodes());
			tempnode.SetLiteralName(inputHigh.GetLiteralName());
			circuitController.GetNodes().Remove(s);
			circuitController.GetNodes().Add(s, tempnode);
			circuitController.GetInputNodes().Remove(s);
			circuitController.GetInputNodes().Add(s, tempnode);
		}

		public void Visit(INode visitee)
		{
			throw new NotImplementedException();
		}
	}
}
