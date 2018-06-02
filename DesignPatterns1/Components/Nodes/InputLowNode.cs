using System;
using System.Collections.Generic;
using DesignPatterns1.Interfaces;
using DesignPatterns1.Visitor;

namespace DesignPatterns1.Nodes
{
	public class InputLowNode : IInputNode
	{
		private List<INode> outputNodes = new List<INode>();
		private List<bool> values = new List<bool>();
		private int inputAmount;
		private String literalName;
		private String name = "INPUT_LOW";
		private bool isInput = true;
		private bool isOutput = false;
		private IOutputHandler handler;

		public String GetName()
		{
			return name;
		}

		public InputLowNode()
		{
			outputNodes = new List<INode>();
			inputAmount = 0;
		}

		public void DoAction()
		{
			outputNodes.ForEach((INode node) => node.AddValue(false));
		}


		public void AddOutputNode(INode node)
		{
			outputNodes.Add(node);
		}

		public void SetOutputNodes(List<INode> outputNodes)
		{
			this.outputNodes = outputNodes;
		}


		public void SetInputAmount(int inputAmount)
		{
			if (inputAmount == 1)
			{
				this.inputAmount = inputAmount;
			}
			else
			{
				this.inputAmount = 1;
			}
		}

		public void AddValue(bool value)
		{
			//values.add(value);
			if (values.Count == inputAmount)
			{
				DoAction();
			}
		}

		public INode Copy()
		{
			return new InputLowNode();
		}
		
		public bool IsInput()
		{
			return isInput;
		}
		
		public bool IsOutput()
		{
			return isOutput;
		}
		
		public void HeightenInputAmount()
		{
			inputAmount++;
		}
		
		public bool DidWork()
		{
			if (values.Count == inputAmount || inputAmount < 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public List<INode> GetOutputNodes()
		{
			return outputNodes;
		}

		public String GetLiteralName()
		{
			return literalName;
		}
		
		public void SetLiteralName(String name)
		{
			this.literalName = name;
		}
		
		public void ClearValues()
		{
			this.values.Clear();
		}

		public void SetOutputHandler(IOutputHandler handler)
		{
			this.handler = handler;
		}
		
		public void Accept(InputNodeVisitor visitor)
		{
			visitor.Visit(this);
		}

		public void AddOutputNode(IOutputNode outputNode)
		{
			outputNodes.Add(outputNode);
		}
	}
}